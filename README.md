# CodeJect
CodeJect is a small, fast and simple DI Container. It uses Code Generation technique via Expression-trees (rather than reflection) for producing the dependencies

CodeJect is an **educational** project. It wasn't intended to be used in production.
  
## Todo:
1. Refactor the builder class to extract logic like finding constructors.
2. Support SingleInstance.
3. Support DependencyPerThread.
4. Register Instance.
5. Custom Action registration.
7. Dispose created IDisposable objects when the container is disposed.
8. Support DependencyPerLifeTimeScope.
9. More Unit Tests.
10. Add options to select a constructor.
