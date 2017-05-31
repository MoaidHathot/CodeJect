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

    public class TypeWithConstructorAcceptingString
    {
        public TypeWithConstructorAcceptingString(string str)
        {
            
        }
    }

    public class TypeWithConstructorAcceptingInt
    {
        public TypeWithConstructorAcceptingInt(int i)
        {
            
        }
    }

    public class TypeWithConstructorAcceptingDobule
    {
        public TypeWithConstructorAcceptingDobule(double d)
        {

        }
    }

    public class TypeWithConstructorAcceptingIntAndDouble
    {
        public TypeWithConstructorAcceptingIntAndDouble(int i, double d)
        {

        }
    }
}
