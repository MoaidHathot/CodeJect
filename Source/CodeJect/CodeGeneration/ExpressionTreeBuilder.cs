using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
namespace CodeJect.CodeGeneration
{
    internal class ExpressionTreeBuilder
    {
        private readonly Type _resolvedType;
        private ConstructorInfo _constructor;
        private readonly IList<Expression> _parameters = new List<Expression>();

        public ExpressionTreeBuilder(Type resolvedType)
        {

            _resolvedType = resolvedType;
        }

        public ExpressionTreeBuilder WithConstructor(ConstructorInfo constructor, params Expression[] parameters) 
            => this.With(() =>
            {
                _constructor = constructor;
                parameters.ForeEach(_parameters.Add);
            });

        public Func<object> Build()
        {
            NewExpression constructor = null == _constructor
                ? Expression.New(_resolvedType)
                : Expression.New(_constructor, _parameters);

           
            var constructorInvoker = Expression.MemberInit(constructor);
            var casting = Expression.Convert(constructorInvoker, typeof(object));
            Debug.WriteLine(constructorInvoker);

            return Expression.Lambda<Func<dynamic>>(casting).Compile();
        }
    }
}
