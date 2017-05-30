using System;
using System.Collections.Generic;
using System.Text;

namespace CodeJect
{
    public interface ICodeJectBuilder
    {
        IRegistrationContext Register(Type registeredType);
    }
}
