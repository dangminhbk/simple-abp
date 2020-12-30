using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Simple.Abp.Dict
{
    public static class CatalogWordMappingEfCoreQueryableExtensions
    {
        public static IQueryable<CatalogWordMapping> IncludeDetails(this IQueryable<CatalogWordMapping> queryable, bool include = true)
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