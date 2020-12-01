using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Users;

namespace Simple.Abp.Articles.EntityFrameworkCore
{
    public class EfCoreArticleRepository : EfCoreRepository<IArticlesDbContext, Article, Guid>,
        IArticleRepository
    {
        private readonly ICurrentUser _currentUser;
        public EfCoreArticleRepository(ICurrentUser currentUser,
            IDbContextProvider<IArticlesDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _currentUser = currentUser;
        }

        public override IQueryable<Article> WithDetails()
        {
            return GetQueryable().Include(x => x.Catalog);
        }

        public virtual IQueryable<Article> WithPublicFilter()
        {
            var userId = _currentUser.Id;
            var query = GetQueryable().Where(c =>
             c.CreatorId != null &&
             (c.State == EnumArticleState.Default
             || (c.State == EnumArticleState.Private && c.CreatorId == userId)));

            return query;
        }
    }
}
