# CodeJect
_CodeJect_ is a small, fast and simple DI Container. It uses Code Generation technique via Expression-trees (rather than reflection) for producing the dependencies

It is built in .Net Core targeting .Net Standard 1.6

_CodeJect_ is an **educational** project. The project is not intended to be used in production.
  
## Already Implemented:
1. Fluent API (Inspired from AutoFac).
2. Generics API implemented as extension methods.
3. Resolving types and dependencies recursively.

## Todo:
1. Refactor the builder class to extract logic like finding constructors.
2. Support SingleInstance.
3. Support DependencyPerThread.
4. Register Instance.
5. Custom Action registration.
6. Dispose created IDisposable objects when the container is disposed.
7. Support DependencyPerLifeTimeScope.
8. More Unit Tests.
9. Add options to select a constructor.
10. Perform performance comparisons between this and Reflection based algorithm.
11. Perform performance comparisons between this and other DI containers.
