using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CodeJect
{
    public interface IRegistrationContext
    {
        IEnumerable<Type> ExposedTypes { get; }
        Type RegisteredType { get; }
        IInstanceScope InstanceScope { get; }

        IRegistrationContext As(Type type);
        IRegistrationContext Scope(IInstanceScope scope);
    }
}
