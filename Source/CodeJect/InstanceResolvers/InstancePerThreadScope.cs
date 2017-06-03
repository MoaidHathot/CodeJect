using System;
using System.Collections.Generic;
using System.Text;

namespace CodeJect
{
    public class InstancePerThreadScope : IInstanceScope
    {
        public object Resolve()
        {
            throw new NotImplementedException();
        }
    }
}
