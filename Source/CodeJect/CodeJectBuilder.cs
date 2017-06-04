using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using CodeJect.CodeGeneration;
using CodeJect.Exceptions;

namespace CodeJect
{
    public sealed class CodeJectBuilder : ICodeJectBuilder
    {
        private readonly Dictionary<Type, IList<IRegistrationContext>> _registrations = new Dictionary<Type, IList<IRegistrationContext>>();

        public IRegistrationContext Register(Type type) 
            => AddContext(type);

        public ITypeResolver Build()
        {
            var registeredInterfaces = _registrations.SelectMany(pair => pair.Value).SelectMany(c => c.ExposedTypes).ToHashSet();
            var selectedConstructors = new Dictionary<Type, ConstructorInfo>();
            var implementedToConcreteTypeMap = new Dictionary<Type, Type>();

            _registrations.ForEach(pair => pair.Value.SelectMany(c => c.ExposedTypes).ForEach(c => implementedToConcreteTypeMap[c] = pair.Key));

            _registrations
                .Select(pair => (pair: pair, Type: pair.Key, TypeInfo: pair.Key.GetTypeInfo(), contexts: pair.Value))
                .If(item => !IsConcreteType(item.TypeInfo), item => throw new TypeRegistrationException(item.Type))
                .Select(item => (Type: item.Type, ConstructorInfo: FindConstructor(item.TypeInfo, registeredInterfaces)))
                .ForEach(item => selectedConstructors[item.Type] = item.ConstructorInfo ??
                    throw new CodeJectException($"Can't resolve dependencies for {item.Type.FullName}."));

            return new CodeJectResolver(implementedToConcreteTypeMap.ToDictionary(pair => pair.Key,
                pair => (Func<object>)(() => GenerateObjectFactor(pair.Value, selectedConstructors, implementedToConcreteTypeMap)())));

            //foreach (var pair in _registrations)
            //{
            //    var typeInfo = pair.Key.GetTypeInfo();

            //    if (typeInfo.IsInterface || typeInfo.IsAbstract)
            //    {
            //        throw new TypeRegistrationException(pair.Key);
            //    }

            //    //var context = pair.Value.Last();

            //    var selectedConstructor = typeInfo
            //        .GetConstructors()
            //        .Where(ctor => ctor.IsPublic)
            //        .Where(ctor => ctor.GetParameters().None() ||
            //                ctor.GetParameters().All(param => allImplementedTypes.Contains(param.ParameterType)))
            //        .OrderByDescending(ctor => ctor.GetParameters().Length)
            //        .FirstOrDefault();

            //    selectedConstructors[pair.Key] = selectedConstructor ?? throw new CodeJectException($"Can't resolve dependencies for {pair.Key.FullName}.");
            //}
            //return new CodeJectResolver(_registrations.Select(pair => (pair.Key, pair.Value.AsEnumerable())));


        }

        private ConstructorInfo FindConstructor(TypeInfo type, ISet<Type> registeredInterfaces)
            => type.GetConstructors()
                .Where(constructor => IsConstructorQualified(constructor, registeredInterfaces))
                .OrderByDescending(constructor => constructor.GetParameters().Length)
                .FirstOrDefault();

        private Func<object> GenerateObjectFactor(Type type, Dictionary<Type, ConstructorInfo> constructorMap, Dictionary<Type, Type> typeMap)
        {
            var constructor = constructorMap[type];
            return new ExpressionTreeBuilder(type).WithConstructor(constructor,
                    constructor.GetParameters()
                        .Select(parm => GenerateObjectFactor(typeMap[parm.ParameterType], constructorMap, typeMap))
                        .ToArray()).Build();
        }

        private IRegistrationContext AddContext(Type type)
        {
            var context = new RegistrationContext(type);

            if (!_registrations.ContainsKey(type))
            {
                _registrations[type] = new List<IRegistrationContext>();
            }

            _registrations[type].Add(context);

            return context;
        }


        private bool IsConstructorQualified(ConstructorInfo constructor, ISet<Type> implementedTypes)
            => constructor.IsPublic &&
                (constructor.GetParameters().None() ||
                 constructor.GetParameters().All(parameter => implementedTypes.Contains(parameter.ParameterType)));

        private bool IsConcreteType(TypeInfo typeInfo)
            => !typeInfo.IsInterface && !typeInfo.IsAbstract;

        public void Dispose()
        {
            _registrations?.Clear();
        }
    }
}
