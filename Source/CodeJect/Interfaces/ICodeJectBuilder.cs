using System;
using System.Collections.Generic;
using System.Text;

namespace CodeJect
{
    public interface ICodeJectBuilder : IDisposable
    {
        IRegistrationContext Register(Type registeredType);
        ITypeResolver Build();
    }
}
