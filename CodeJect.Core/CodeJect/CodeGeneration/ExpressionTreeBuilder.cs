using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CodeJect.CodeGeneration
{
    internal class ExpressionTreeBuilder
    {
        private readonly Type _resolvedType;

        private const BindingFlags ConstructorBindingFlags =
            BindingFlags.CreateInstance | BindingFlags.Public | BindingFlags.Instance;

        public ExpressionTreeBuilder(Type resolvedType)
        {
            _resolvedType = resolvedType;
        }


        public ExpressionTreeBuilder WithDependency(Type dependencyType, Func<object> dependencyFactory)
        {
            return this;
        }

        public Func<object> Build()
        {
            Expression<Func<object>> expression = () => Activator.CreateInstance(_resolvedType);

            return expression.Compile();
        }
    }
}
