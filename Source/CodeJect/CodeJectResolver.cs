using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CodeJect.Exceptions;

namespace CodeJect
{
    internal class CodeJectResolver : ITypeResolver
    {
        private readonly IDictionary<Type, Func<object>> _registrations;
        private LinkedList<object> _createdObjects = new LinkedList<object>();

        public CodeJectResolver(IDictionary<Type, Func<object>> registrations)
        {
            _registrations = registrations;
        }

        public object Resolver(Type type)
        {
            if (!_registrations.ContainsKey(type))
            {
                throw new TypeResolveException(type);
            }

            return _createdObjects.AddLast(_registrations[type]()).Value;
        }

        public void Dispose()
        {
           _createdObjects?
                .Select(item => item as IDisposable)
                .ForEach(item => item?.Dispose());
        }
    }
}
