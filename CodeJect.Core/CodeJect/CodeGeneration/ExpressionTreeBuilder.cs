﻿using System;
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
            var constructor = Expression.New(_resolvedType);
            var constructorInvoker = Expression.MemberInit(constructor);
            var casting = Expression.Convert(constructorInvoker, typeof(object));
            Debug.WriteLine(constructorInvoker);

            return Expression.Lambda<Func<dynamic>>(casting).Compile();
        }
    }
}
