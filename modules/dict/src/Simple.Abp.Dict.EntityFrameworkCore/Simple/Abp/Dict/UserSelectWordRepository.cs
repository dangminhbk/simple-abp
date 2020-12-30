using System;
using Simple.Abp.Dict.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Simple.Abp.Dict
{
    public class UserSelectWordRepository : EfCoreRepository<IDictDbContext, UserSelectWord, Guid>, IUserSelectWordRepository
    {
        public UserSelectWordRepository(IDbContextProvider<IDictDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}