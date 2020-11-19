using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Uow;

namespace Simple.Abp.Articles
{
    public class ArticleManager : IArticleManager, IScopedDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IArticleRepository _articleRepository;
        private readonly ITagRepository _tagRepository;

        public ArticleManager(IGuidGenerator guidGenerator,
            IArticleRepository articleRepository,
            ITagRepository tagRepository)
        {
            _guidGenerator = guidGenerator;
            _articleRepository = articleRepository;
            _tagRepository = tagRepository;
        }

        private async Task HandleTagAsync(Article article)
        {
            if (article.Tag.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(Article.Tag));

            article.Tag = article.Tag.Trim();

            var anyTag = await _tagRepository.AnyByNameAsync(article.Tag);
            if (anyTag)
                return;

            var tagId = _guidGenerator.Create();
            Tag tagEntity = new Tag(tagId, article.Tag);
            await _tagRepository.InsertAsync(tagEntity);
        }

        [UnitOfWork]
        public async Task<Article> CreateAsync(Article article)
        {
            await HandleTagAsync(article);
            return await _articleRepository.InsertAsync(article);
        }

        public async Task<Article> UpdateAsync(Article article)
        {
            await HandleTagAsync(article);
            return await _articleRepository.UpdateAsync(article);
        }
    }
}
