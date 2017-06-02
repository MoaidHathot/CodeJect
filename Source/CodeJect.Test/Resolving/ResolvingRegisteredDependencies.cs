using System;
using System.Collections.Generic;
using System.Text;
using CodeJect.Exceptions;
using CodeJect.Test.Utility;
using Xunit;

namespace CodeJect.Test.Resolving
{
    public class ResolvingRegisteredDependencies
    {
        [Fact]
        public void Resolve_ClassWithNoRegistrations_ExceptionIsThrown()
        {
            var builder = new CodeJectBuilder();
            var resolver = builder.Build();

            Assert.Throws<TypeResolveException>(() => resolver.Resolve<ITestingInterface1>());
        }

        [Fact]
        public void Resolve_RegisterClassWithNoDependencies_ObjectResolved()
        {
            var builder = new CodeJectBuilder();

            builder.Register<TypeImplementingInterface1>().As<ITestingInterface1>();
            var resolver = builder.Build();

            var resolved = resolver.Resolve<ITestingInterface1>();

            Assert.IsType<TypeImplementingInterface1>(resolved);
        }

        [Fact]
        public void Resolve_RegisterClassWithOneDependencies_ObjectResolved()
        {
            var builder = new CodeJectBuilder();

            builder.Register<TypeImplementingInterface1>().As<ITestingInterface1>();

            builder.Register<TypeDependsOnTypeImplementingInterface1>().AsSelf();
            var resolver = builder.Build();

            var resolved = resolver.Resolve<TypeDependsOnTypeImplementingInterface1>();

            Assert.IsType<TypeDependsOnTypeImplementingInterface1>(resolved);
            Assert.NotNull(resolved.TestingInterface1);
            Assert.IsType<TypeImplementingInterface1>(resolved.TestingInterface1);
        }

        [Fact]
        public void Resolve_RegisterClassWithTwoDependencies_ObjectResolved()
        {
            var builder = new CodeJectBuilder();

            builder.Register<TypeImplementingInterface1>().As<ITestingInterface1>();
            builder.Register<TypeImplementingInterface2>().As<ITestingInterface2>();
            builder.Register<TypeDepensOnTwoTypesImplementingInterface1And2>().AsSelf();
            var resolver = builder.Build();

            var resolved = resolver.Resolve<TypeDepensOnTwoTypesImplementingInterface1And2>();

            Assert.IsType<TypeDepensOnTwoTypesImplementingInterface1And2>(resolved);
            Assert.NotNull(resolved.TestingInterface2);
            Assert.NotNull(resolved.TestingInterface1);
            Assert.IsType<TypeImplementingInterface1>(resolved.TestingInterface1);
            Assert.IsType<TypeImplementingInterface2>(resolved.TestingInterface2);
        }

        [Fact]
        public void Resolve_RegisterAClassDependentOnAnotherDependentClass_ObjectResolved()
        {
            var builder = new CodeJectBuilder();

            builder.Register<TypeImplementingInterface1>().As<ITestingInterface1>();
            builder.Register<TypeImplementingInterface2>().As<ITestingInterface2>();
            builder.Register<TypeDepensOnTwoTypesImplementingInterface1And2>().AsSelf();
            builder.Register<TypeDependsOnDependentTypeOfTypeImplementingInterface1And2>().AsSelf();
            var resolver = builder.Build();

            var resolved = resolver.Resolve<TypeDependsOnDependentTypeOfTypeImplementingInterface1And2>();

            Assert.IsType<TypeDependsOnDependentTypeOfTypeImplementingInterface1And2>(resolved);
            Assert.NotNull(resolved.TypeDepensOnTwoTypesImplementingInterface1And2);
            Assert.IsType<TypeDepensOnTwoTypesImplementingInterface1And2>(resolved.TypeDepensOnTwoTypesImplementingInterface1And2);
            Assert.NotNull(resolved.TypeDepensOnTwoTypesImplementingInterface1And2.TestingInterface2);
            Assert.NotNull(resolved.TypeDepensOnTwoTypesImplementingInterface1And2.TestingInterface1);
            Assert.IsType<TypeImplementingInterface1>(resolved.TypeDepensOnTwoTypesImplementingInterface1And2.TestingInterface1);
            Assert.IsType<TypeImplementingInterface2>(resolved.TypeDepensOnTwoTypesImplementingInterface1And2.TestingInterface2);
        }
    }

}
