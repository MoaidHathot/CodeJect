using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using CodeJect.CodeGeneration;
using CodeJect.Test.Utility;
using Xunit;

namespace CodeJect.Test.CodeGenration
{
    public class ExpressionTreeTests
    {
        [Theory]
        [InlineData(typeof(int))]
        [InlineData(typeof(ulong))]
        [InlineData(typeof(StringBuilder))]
        [InlineData(typeof(double))]
        [InlineData(typeof(TypeWithNoExplicitConstructor))]
        [InlineData(typeof(TypeWithDefaultConstructor))]
        [InlineData(typeof(TypeWithDefaultConstructorOnly))]
        public void Compile_TypeWithDefaultConstructor_ObjectGenerated(Type type)
        {
            var builder = new ExpressionTreeBuilder(type);

            var factory = builder.Build();

            var created = factory();

            Assert.NotNull(created);
            Assert.IsType(type, created);
        }

        [Theory]
        [InlineData(typeof(TypeWithConstructorAcceptingInt), 1)]
        [InlineData(typeof(TypeWithConstructorAcceptingInt), 42)]
        [InlineData(typeof(TypeWithConstructorAcceptingInt), -10)]
        [InlineData(typeof(TypeWithConstructorAcceptingDobule), 1.0)]
        [InlineData(typeof(TypeWithConstructorAcceptingDobule), 10.3)]
        [InlineData(typeof(TypeWithConstructorAcceptingDobule), 66D)]
        [InlineData(typeof(TypeWithConstructorAcceptingString), "")]

        public void Compile_TypeWithConstructorAcceptingConstantParameter_ObjectGenerated(Type type, object parameter)
        {
            var builder = new ExpressionTreeBuilder(type);

            builder.WithConstructor(type.GetConstructors().First(ctr => ctr.GetParameters().Length == 1), Expression.Constant(parameter));
            var factory = builder.Build();

            var created = factory();

            Assert.NotNull(created);
            Assert.IsType(type, created);
        }

        [Theory]
        [InlineData(typeof(TypeWithConstructorAcceptingString), "")]
        [InlineData(typeof(TypeWithConstructorAcceptingString), "CodeJect")]
        [InlineData(typeof(TypeWithConstructorAcceptingString), "Code Ject")]
        [InlineData(typeof(TypeWithConstructorAcceptingString), null)]
        public void Compile_TwypWithConstructorAcceptingStringParameter_ObjectGenerated(Type type, string parameter)
        {
            var builder = new ExpressionTreeBuilder(type);

            builder.WithConstructor(type.GetConstructors().First(ctr => ctr.GetParameters().Length == 1), Expression.Constant(parameter, typeof(string)));
            var factory = builder.Build();

            var created = factory();

            Assert.NotNull(created);
            Assert.IsType(type, created);
        }
    }  
}
