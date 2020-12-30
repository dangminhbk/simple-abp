using System;
using Simple.Abp.Dict.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Simple.Abp.Dict
{
    public class UserCatalogMappingRepository : EfCoreRepository<IDictDbContext, UserCatalogMapping, Guid>, IUserCatalogMappingRepository
    {
        public UserCatalogMappingRepository(IDbContextProvider<IDictDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}