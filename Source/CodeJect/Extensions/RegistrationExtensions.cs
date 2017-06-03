using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CodeJect
{
    public static class RegistrationExtensions
    {
        public static IRegistrationContext AsSelf(this IRegistrationContext context)  
            => context.As(context.RegisteredType);

        public static IRegistrationContext As<TType>(this IRegistrationContext context)
            => context.As(typeof(TType));

        public static IRegistrationContext AsImplementedInterfaces(this IRegistrationContext context)
        {
            context.RegisteredType.GetTypeInfo().GetInterfaces().ForEach(type => context.As(type));
            return context;
        }
    }
}
