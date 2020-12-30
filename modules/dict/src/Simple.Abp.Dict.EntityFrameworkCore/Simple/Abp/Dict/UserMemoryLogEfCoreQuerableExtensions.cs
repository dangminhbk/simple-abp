using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Simple.Abp.Dict
{
    public static class UserMemoryLogEfCoreQueryableExtensions
    {
        public static IQueryable<UserMemoryLog> IncludeDetails(this IQueryable<UserMemoryLog> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                // .Include(x => x.xxx) // TODO: AbpHelper generated
                ;
        }
    }
}