using System;
using System.Collections.Generic;
using System.Text;

namespace CodeJect
{
    public interface IContainerBuilder
    {
        IRegistrationContext Register(Type type);

        IInstanceResolver Build();
    }
}
