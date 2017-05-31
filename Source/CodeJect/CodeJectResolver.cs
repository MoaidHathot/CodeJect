using System;
using System.Collections.Generic;
using System.Text;

namespace CodeJect
{
    internal class CodeJectResolver : IInstanceResolver
    {
        public CodeJectResolver(IEnumerable<(Type registeredType, IEnumerable<IRegistrationContext> contexts)> registrations)
        {
            
        }

        public object Resolver(Type type)
        {
            return null;
        }
    }
}
