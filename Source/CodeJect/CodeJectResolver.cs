using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using CodeJect.Exceptions;

namespace CodeJect
{
    internal class CodeJectResolver : IInstanceResolver
    {
        private readonly IDictionary<Type, Func<object>> _registrations;

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

            return _registrations[type]();
        }
    }
}
