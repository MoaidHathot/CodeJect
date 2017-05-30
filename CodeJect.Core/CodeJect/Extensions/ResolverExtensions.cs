using CodeJect.Interfaces;

namespace CodeJect
{
    public static class ResolverExtensions
    {
        public static T Resolve<T>(this ICodeJectResolver resolver)
            => (T) resolver.Resolver(typeof(T));
    }
}
