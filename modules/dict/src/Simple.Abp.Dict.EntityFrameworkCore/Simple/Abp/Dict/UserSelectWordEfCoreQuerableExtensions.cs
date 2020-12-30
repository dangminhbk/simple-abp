using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Simple.Abp.Dict
{
    public static class UserSelectWordEfCoreQueryableExtensions
    {
        public static IQueryable<UserSelectWord> IncludeDetails(this IQueryable<UserSelectWord> queryable, bool include = true)
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