using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Abp.Articles
{
    public interface IArticleManager
    {
        Task<Article> CreateAsync(Article article);

        Task<Article> UpdateAsync(Article article);
    }
}
