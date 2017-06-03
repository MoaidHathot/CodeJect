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

        public void Dispose()
        {
           _registrations?
                .Select(pair => pair.Value())
                .Where(item => item is IDisposable)
                .ForEach(item => ((IDisposable)item).Dispose());
        }
    }
}
