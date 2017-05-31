using System;
using System.Collections.Generic;
using System.Text;

namespace CodeJect.Exceptions
{
    public class TypeResolveException : CodeJectException
    {
 
        public TypeResolveException(Type type, string name = "")
            : base($"Can't resolve an instance of type '{type.FullName}' {(string.IsNullOrWhiteSpace(name) ? $"nameed '{name}'" : string.Empty)}")
        {
        }
    }
}
