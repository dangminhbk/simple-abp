using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Simple.Abp.Articles.EntityFrameworkCore
{
    public class EfCoreTagRepository : EfCoreRepository<IArticlesDbContext, Tag, Guid>,ITagRepository

    {
        
        public EfCoreTagRepository(IDbContextProvider<IArticlesDbContext> 
            dbContextProvider) : base(dbContextProvider)
        {
        }

        public Task<bool> AnyByNameAsync(string name)
        {
            return DbSet.AnyAsync(c => c.Name == name);
        }
    }
}
