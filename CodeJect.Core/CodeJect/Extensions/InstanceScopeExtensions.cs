using System;
using System.Collections.Generic;
using System.Text;

namespace CodeJect
{
    public static class InstanceScopeExtensions
    {
        public static IRegistrationContext SingleInstance(this IRegistrationContext context)
            => context.Scope(new SingleInstanceScope());

        public static IRegistrationContext InstancePerDependency(this IRegistrationContext context)
            => context.Scope(new InstancePerDependencyScope());

        public static IRegistrationContext InstancePerThread(this IRegistrationContext context)
            => context.Scope(new InstancePerThreadScope());
    }
}
