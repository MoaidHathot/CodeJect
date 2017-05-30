using System;
using System.Collections.Generic;
using System.Text;

namespace CodeJect
{
    public sealed class CodeJectBuilder
    {
        public IRegistrationContext Register(Type type)
        {
            return new RegistrationContext(type).As<string>();
        }
    }
}
