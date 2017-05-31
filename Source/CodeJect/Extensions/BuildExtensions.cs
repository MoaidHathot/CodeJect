using System;
using System.Collections.Generic;
using System.Text;

namespace CodeJect
{
    public static class BuildExtensions
    {
        public static IRegistrationContext Register<T>(this ICodeJectBuilder builder)
        {
            return builder.Register(typeof(T));
        }
    }
}
