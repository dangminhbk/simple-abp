using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace Simple.Abp.Articles
{
    public interface IArticleRepository: IRepository<Article, Guid>
    {
        IQueryable<Article> WithPublicFilter();
    }
}
