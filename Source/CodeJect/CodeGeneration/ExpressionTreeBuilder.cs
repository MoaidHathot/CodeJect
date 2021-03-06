﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
                parameters.ForEach(_parameters.Add);
            });

        public ExpressionTreeBuilder WithConstructor(ConstructorInfo constructor, params Func<object>[] parameters)
        {
            return WithConstructor(constructor, parameters.Select(param =>
            {
                var obj = param();
                return (Expression)Expression.Constant(obj, obj?.GetType());
            }).ToArray());
        }

        public Func<object> Build()
        {
            NewExpression constructor = null == _constructor
                ? Expression.New(_resolvedType)
                : Expression.New(_constructor, _parameters);

           
            var constructorInvoker = Expression.MemberInit(constructor);
            var casting = Expression.Convert(constructorInvoker, typeof(object));

            return Expression.Lambda<Func<dynamic>>(casting).Compile();
        }
    }
}
