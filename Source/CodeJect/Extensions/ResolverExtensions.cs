namespace CodeJect
{
    public static class ResolverExtensions
    {
        public static T Resolve<T>(this ITypeResolver resolver)
            => (T) resolver.Resolver(typeof(T));
    }
}
