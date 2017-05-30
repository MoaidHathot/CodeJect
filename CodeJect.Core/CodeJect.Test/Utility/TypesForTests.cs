using System;
using System.Collections.Generic;
using System.Text;

namespace CodeJect.Test.Utility
{
    public class TypeWithNoExplicitConstructor
    {
        
    }

    public class TypeWithDefaultConstructorOnly
    {
        public TypeWithDefaultConstructorOnly()
        {
            
        }    
    }

    public class TypeWithDefaultConstructor
    {
        public TypeWithDefaultConstructor()
        {
            
        }

        public TypeWithDefaultConstructor(string str)
        {
              
        }
    }

    public class TypeWithConstructorWithReferenceTypeParameter
    {
        public TypeWithConstructorWithReferenceTypeParameter(string str)
        {

        }
    }

    public class TypeWithConstructorWithValueTypeParameter
    {
        public TypeWithConstructorWithValueTypeParameter(ulong l)
        {
            
        }
    }
}
