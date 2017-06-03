using System;
using System.Collections.Generic;
using System.Text;

namespace CodeJect
{
    public interface ITypeResolver
    {
        object Resolver(Type type);
    }
}
