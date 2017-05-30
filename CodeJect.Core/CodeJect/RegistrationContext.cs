using System;
using System.Collections.Generic;
using System.Text;

namespace CodeJect
{
    internal class RegistrationContext : IRegistrationContext
    {
        private readonly ISet<Type> _dependencyTypes = new HashSet<Type>();

        public Type RegisteredType { get; }
        public IInstanceScope InstanceScope { get; private set; }
        

        internal RegistrationContext(Type registeredType)
        {
            RegisteredType = registeredType;
        }

        public IRegistrationContext As(Type type)
            => this.With(() => _dependencyTypes.Add(type));

        public IRegistrationContext Scope(IInstanceScope scope) 
            => this.With(() => InstanceScope = scope);

 
    }
}
