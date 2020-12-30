using System;
using Simple.Abp.Dict.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Simple.Abp.Dict
{
    public class CatalogWordMappingRepository : EfCoreRepository<IDictDbContext, CatalogWordMapping, Guid>, ICatalogWordMappingRepository
    {
        public CatalogWordMappingRepository(IDbContextProvider<IDictDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}