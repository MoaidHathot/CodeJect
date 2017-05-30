using System;
using System.Collections.Generic;
using System.Text;
using CodeJect.CodeGeneration;
using CodeJect.Test.Utility;
using Xunit;

namespace CodeJect.Test.CodeGenration
{
    public class ExpressionTreeTests
    {
        [Theory]
        [InlineData(typeof(string))]
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
    }
}
