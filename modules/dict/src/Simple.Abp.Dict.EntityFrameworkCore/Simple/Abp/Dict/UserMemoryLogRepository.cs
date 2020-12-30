using System;
using Simple.Abp.Dict.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Simple.Abp.Dict
{
    public class UserMemoryLogRepository : EfCoreRepository<IDictDbContext, UserMemoryLog, Guid>, IUserMemoryLogRepository
    {
        public UserMemoryLogRepository(IDbContextProvider<IDictDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}