using System;
using System.Collections.Generic;
using System.Text;

namespace CodeJect.Exceptions
{
    public class CodeJectException : Exception
    {
        public CodeJectException()
        {
        }

        public CodeJectException(string message) 
            : base(message)
        {
        }

        public CodeJectException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
