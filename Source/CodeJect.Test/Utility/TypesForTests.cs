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

    public interface ITestingInterface1
    {
        
    }

    public interface ITestingInterface2
    {
        
    }

    public interface ITestingInterface3
    {
        
    }

    public class TypeImplementingInterface1 : ITestingInterface1
    {
        
    }

    public class TypeImplementingInterface2 : ITestingInterface2
    {
        
    }

    public class TypeImplementingInterface3 : ITestingInterface3
    {
        
    }

    public class TypeDependsOnTypeImplementingInterface1
    {
        public ITestingInterface1 TestingInterface1 { get; set; }

        public TypeDependsOnTypeImplementingInterface1(ITestingInterface1 testingInterface1)
        {
            TestingInterface1 = testingInterface1;
        }
    }

    public class TypeDepensOnTwoTypesImplementingInterface1And2
    {
        public ITestingInterface1 TestingInterface1 { get; set; }
        public ITestingInterface2 TestingInterface2 { get; set; }

        public TypeDepensOnTwoTypesImplementingInterface1And2(ITestingInterface1 testingInterface1, ITestingInterface2 testingInterface2)
        {
            TestingInterface1 = testingInterface1;
            TestingInterface2 = testingInterface2;
        }
    }

    public class TypeDependsOnDependentTypeOfTypeImplementingInterface1And2
    {
        public TypeDepensOnTwoTypesImplementingInterface1And2 TypeDepensOnTwoTypesImplementingInterface1And2 { get; set; }

        public TypeDependsOnDependentTypeOfTypeImplementingInterface1And2(TypeDepensOnTwoTypesImplementingInterface1And2 typeDepensOnTwoTypesImplementingInterface1And2)
        {
            TypeDepensOnTwoTypesImplementingInterface1And2 = typeDepensOnTwoTypesImplementingInterface1And2;
        }
    }
}
