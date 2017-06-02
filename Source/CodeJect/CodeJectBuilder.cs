using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CodeJect.CodeGeneration;
using CodeJect.Exceptions;

namespace CodeJect
{
    public sealed class CodeJectBuilder : IContainerBuilder
    {
        private readonly Dictionary<Type, IList<IRegistrationContext>> _registrations = new Dictionary<Type, IList<IRegistrationContext>>();

        public IRegistrationContext Register(Type type) 
            => AddContext(type);

        public IInstanceResolver Build()
        {
            var allExposedTypes = _registrations.SelectMany(pair => pair.Value).SelectMany(c => c.ExposedTypes).ToHashSet();
            var selectedConstructors = new Dictionary<Type, ConstructorInfo>();
            var typeMap = new Dictionary<Type, Type>();

            _registrations.ForeEach(pair => pair.Value.SelectMany(c => c.ExposedTypes).ForeEach(c => typeMap[c] = pair.Key));


            foreach (var pair in _registrations)
            {
                var typeInfo = pair.Key.GetTypeInfo();

                if (typeInfo.IsInterface || typeInfo.IsAbstract)
                {
                    throw new TypeRegistrationException(pair.Key);
                }

                var context = pair.Value.Last();

                var selectedConstructor = typeInfo
                    .GetConstructors(BindingFlags.Public)
                    .Where(ctor => ctor.GetParameters().None() ||
                            ctor.GetParameters().All(param => allExposedTypes.Contains(param.ParameterType)))
                    .OrderByDescending(ctor => ctor.GetParameters().Length)
                    .FirstOrDefault();

                selectedConstructors[pair.Key] = selectedConstructor ?? throw new CodeJectException($"Can't resolve dependencies for {pair.Key.FullName}.");
            }
            //return new CodeJectResolver(_registrations.Select(pair => (pair.Key, pair.Value.AsEnumerable())));

            selectedConstructors.ForeEach(pair => GenerateObjectFactor(pair.Key, selectedConstructors, typeMap));
        }

        private Func<object> GenerateObjectFactor(Type type, Dictionary<Type, ConstructorInfo> constructorMap, Dictionary<Type, Type> typeMap)
        {
            var constructor = constructorMap[type];
            return
                new ExpressionTreeBuilder(type).WithConstructor(constructor,
                    constructor.GetParameters()
                        .Select(parm => GenerateObjectFactor(parm.ParameterType, constructorMap, typeMap))
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
    }
}
