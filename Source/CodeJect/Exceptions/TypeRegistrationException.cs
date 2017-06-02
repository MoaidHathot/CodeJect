using System;
using System.Collections.Generic;
using System.Text;

namespace CodeJect.Exceptions
{
    public class TypeRegistrationException : CodeJectException
    {
        public TypeRegistrationException(Type type)
            : base($"Interface or Abstract type '{type.FullName}' can't be registered. Only concrete types can be registered.")
        {
        }
    }
}
