using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeJect
{
    public sealed class CodeJectBuilder : IContainerBuilder
    {
        private readonly Dictionary<Type, IList<IRegistrationContext>> _registrations = new Dictionary<Type, IList<IRegistrationContext>>();

        public IRegistrationContext Register(Type type) 
            => AddContext(type);

        public IInstanceResolver Build() 
            => new CodeJectResolver(_registrations.Select(pair => (pair.Key, pair.Value.AsEnumerable())));

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
