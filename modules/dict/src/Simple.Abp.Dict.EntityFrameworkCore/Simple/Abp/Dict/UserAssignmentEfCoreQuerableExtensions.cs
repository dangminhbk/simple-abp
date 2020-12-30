using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Simple.Abp.Dict
{
    public static class UserAssignmentEfCoreQueryableExtensions
    {
        public static IQueryable<UserAssignment> IncludeDetails(this IQueryable<UserAssignment> queryable, bool include = true)
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