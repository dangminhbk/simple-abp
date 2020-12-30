using System;
using Simple.Abp.Dict.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Simple.Abp.Dict
{
    public class WordRepository : EfCoreRepository<IDictDbContext, Word, Guid>, IWordRepository
    {
        public WordRepository(IDbContextProvider<IDictDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}