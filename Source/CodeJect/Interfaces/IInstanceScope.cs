using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CodeJect
{
    public interface IInstanceScope
    {
        object Resolve();
    }
}
