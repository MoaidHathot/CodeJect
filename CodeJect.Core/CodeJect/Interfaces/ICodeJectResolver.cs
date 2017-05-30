using System;
using System.Collections.Generic;
using System.Text;

namespace CodeJect.Interfaces
{
    public interface ICodeJectResolver
    {
        object Resolver(Type type);
    }
}
