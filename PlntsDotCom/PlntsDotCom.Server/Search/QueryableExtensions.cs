using System.Linq.Expressions;

namespace PlntsDotCom.Server.Search
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Where<T>(this IQueryable<T> source, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition
                ? source.Where(predicate)
                : source;

        }
    }
}
