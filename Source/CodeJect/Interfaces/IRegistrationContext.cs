using System;
using System.Collections.Generic;
using System.Text;

namespace CodeJect
{
    public interface IRegistrationContext
    {
        Type RegisteredType { get; }
        IInstanceScope InstanceScope { get; }

        IRegistrationContext As(Type type);
        IRegistrationContext Scope(IInstanceScope scope);
    }
}
