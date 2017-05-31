using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
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
        public ulong Value { get; set; }

        public TypeWithConstructorWithValueTypeParameter(ulong l)
        {
            Value = l;
        }
    }

    public class TypeWithConstructorAcceptingString
    {
        public string Value { get; set; }   
        public TypeWithConstructorAcceptingString(string str)
        {
            Value = str;
        }
    }

    public class TypeWithConstructorAcceptingInt
    {
        public int Value { get; set; }
        public TypeWithConstructorAcceptingInt(int i)
        {
            Value = i;
        }
    }

    public class TypeWithConstructorAcceptingDobule
    {
        public double Value { get; set; }
        public TypeWithConstructorAcceptingDobule(double d)
        {
            Value = d;
        }
    }

    public class TypeWithConstructorAcceptingIntAndDouble
    {
        public int IntValue { get; set; }
        public double DoubleValue { get; set; }
        public TypeWithConstructorAcceptingIntAndDouble(int i, double d)
        {
            IntValue = i;
            DoubleValue = d;
        }
    }
}
