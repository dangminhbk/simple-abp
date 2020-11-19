using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Simple.Abp.Articles.EntityFrameworkCore
{
    public class EfCoreArticleRepository : EfCoreRepository<IArticlesDbContext, Article, Guid>,
        IArticleRepository
    {
        public EfCoreArticleRepository(IDbContextProvider<IArticlesDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override IQueryable<Article> WithDetails()
        {
            return GetQueryable().Include(x => x.Catalog);
        }


    }
}
