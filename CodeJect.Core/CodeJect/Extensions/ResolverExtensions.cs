namespace CodeJect
{
    public static class ResolverExtensions
    {
        public static T Resolve<T>(this IInstanceResolver resolver)
            => (T) resolver.Resolver(typeof(T));
    }
}
