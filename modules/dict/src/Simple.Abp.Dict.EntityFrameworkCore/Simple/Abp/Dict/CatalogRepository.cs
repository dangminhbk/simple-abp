using System;
using Simple.Abp.Dict.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Simple.Abp.Dict
{
    public class CatalogRepository : EfCoreRepository<IDictDbContext, Catalog, Guid>, ICatalogRepository
    {
        public CatalogRepository(IDbContextProvider<IDictDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}