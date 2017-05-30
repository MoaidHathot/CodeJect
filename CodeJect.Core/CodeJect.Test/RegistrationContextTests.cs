using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeJect.Test
{
    public class RegistrationContextTests
    {
        [Theory]
        [InlineData(typeof(int))]
        [InlineData(typeof(string))]
        [InlineData(typeof(ulong))]
        [InlineData(typeof(List<Action>))]
        [InlineData(typeof(List<Func<int>>))]
        [InlineData(typeof(List<Action<string>>))]
        [InlineData(typeof(List<StringBuilder>))]
        [InlineData(typeof(StringBuilder))]
        [InlineData(typeof(CodeJectBuilder))]
        [InlineData(typeof(object))]

        public void RegisterWithTypeParameter_Type_PropertyValueShouldBeOfSameType(Type type)
        {
            var container = new CodeJectBuilder();

            var context = container.Register(typeof(int));

            Assert.Equal(typeof(int), context.RegisteredType);
        }
    } 
}
