using System;
using System.Collections.Generic;
using System.Text;

namespace CodeJect
{
    public interface IInstanceResolver
    {
        object Resolver(Type type);
    }
}
