using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Simple.Abp.Dict
{
    public static class WordEfCoreQueryableExtensions
    {
        public static IQueryable<Word> IncludeDetails(this IQueryable<Word> queryable, bool include = true)
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