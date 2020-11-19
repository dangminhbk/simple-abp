using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Simple.Abp.Articles.EntityFrameworkCore
{
    public class EfCoreCatalogRepository : EfCoreRepository<IArticlesDbContext, Catalog, Guid>, ICatalogRepository
    {
        public EfCoreCatalogRepository(IDbContextProvider<IArticlesDbContext> 
            dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
