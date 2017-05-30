using System;
using System.Collections.Generic;
using System.Text;

namespace CodeJect
{
    public static class FluentApiExtensions
    {
        public static T With<T>(this T @this, Action sideEffect)
        {
            sideEffect();

            return @this;
        }
    } 
}
