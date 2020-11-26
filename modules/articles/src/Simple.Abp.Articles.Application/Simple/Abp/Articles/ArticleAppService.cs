using Microsoft.AspNetCore.Authorization;
using Simple.Abp.Articles.Dtos;
using Simple.Abp.Articles.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Linq;

namespace Simple.Abp.Articles
{
    public class ArticleAppService : CrudAppService<
        Article,
        ArticleDto, 
        Guid, 
        ArticlePagedRequestDto,
        CreateUpdateArticleDto, 
        CreateUpdateArticleDto>,
        IArticleAppService
    {
        protected override string GetPolicyName { get; set; } = ArticlesPermissions.Article.Default;
        protected override string GetListPolicyName { get; set; } = ArticlesPermissions.Article.Default;
        protected override string CreatePolicyName { get; set; } = ArticlesPermissions.Article.Create;
        protected override string UpdatePolicyName { get; set; } = ArticlesPermissions.Article.Update;
        protected override string DeletePolicyName { get; set; } = ArticlesPermissions.Article.Delete;


        private readonly IArticleRepository _repository;

        private readonly IArticleManager _articleManager;

        private readonly IAsyncQueryableExecuter _asyncExecuter;
        public ArticleAppService(IArticleRepository repository,
            IArticleManager articleManager,
             IAsyncQueryableExecuter asyncExecuter) : base(repository)
        {
            _repository = repository;
            _articleManager = articleManager;
            _asyncExecuter = asyncExecuter;
        }

        private async Task<ArticleDto> BuildArticleDto(IQueryable<Article> query, Article entity)
        {
            if (entity == null)
                return null;

            // 上一篇
            var previousQuery = query.Where(c => c.CreationTime > entity.CreationTime)
                .OrderBy(c => c.CreationTime);
            var previousEntity = await _asyncExecuter.FirstOrDefaultAsync(previousQuery);

            // 下一篇
            var nextQuery = query.Where(c => c.CreationTime < entity.CreationTime)
                .OrderByDescending(c=>c.CreationTime);
            var nextEntity = await _asyncExecuter.FirstOrDefaultAsync(nextQuery);

            var model = ObjectMapper.Map<Article, ArticleDto>(entity);
            model.Previous = ObjectMapper.Map<Article, ArticleDto>(previousEntity);
            model.Next = ObjectMapper.Map<Article, ArticleDto>(nextEntity);

            return model;
        }


        protected override IQueryable<Article> CreateFilteredQuery(ArticlePagedRequestDto input)
        {
            var query = _repository.WithDetails();
            if (!input.Filter.IsNullOrWhiteSpace())
                query = query.Where(c => c.Title.Contains(input.Filter));

            if (!input.CatalogTitle.IsNullOrWhiteSpace())
                query = query.Where(c => c.Catalog.Title == input.CatalogTitle);

            if (!input.TagName.IsNullOrWhiteSpace())
                query = query.Where(c => c.Tag == input.TagName);

            return query;
        }

        protected virtual IQueryable<Article> JoinPublicFilteredQuery(IQueryable<Article> query)
        {
            return query.Where(c => c.State != EnumArticleState.Draft)
               .Where(c => (c.State != EnumArticleState.Private || c.CreatorId == CurrentUser.Id));
        }

        protected override IQueryable<Article> ApplyDefaultSorting(IQueryable<Article> query)
        {
            query = query.OrderByDescending(c => c.IsTop)
                .ThenByDescending(c => c.CreationTime);

            return query;
        }

        public async Task<ArticleDto> GetPublicAsync(Guid id)
        {
            var query = _repository.WithDetails();
            query = JoinPublicFilteredQuery(query);

            var entityQuery = query.Where(c => c.Id == id);
            var entity = await _asyncExecuter.FirstOrDefaultAsync(entityQuery);

            return await BuildArticleDto(query, entity);
        }

        public async Task<ArticleDto> GetPublicBySEOAsync(string seoPath)
        {
            var query = _repository.WithDetails();
            query = JoinPublicFilteredQuery(query);

            var entityQuery = query.Where(c => c.SEOPath == seoPath);
            var entity = await _asyncExecuter.FirstOrDefaultAsync(entityQuery);
            return await BuildArticleDto(query, entity);
        }

        public async Task<PagedResultDto<ArticleDto>> GetPublicListAsync(ArticlePagedRequestDto request)
        {
            var query = CreateFilteredQuery(request);
            query = JoinPublicFilteredQuery(query);

            var totalCount = await _asyncExecuter.CountAsync(query);

            query = ApplyDefaultSorting(query);
            query = query.Skip(request.SkipCount).Take(request.MaxResultCount);
         
            var entities = await _asyncExecuter.ToListAsync(query);
            var modelList = ObjectMapper.Map<List<Article>, List<ArticleDto>>(entities);
            return new PagedResultDto<ArticleDto>(totalCount, modelList);
        }

        [Authorize(ArticlesPermissions.Article.Create)]
        public override async Task<ArticleDto> CreateAsync(CreateUpdateArticleDto input)
        {
            var entity = ObjectMapper.Map<CreateUpdateArticleDto, Article>(input);
            entity = await _articleManager.CreateAsync(entity);
            return ObjectMapper.Map<Article, ArticleDto>(entity);
        }

        [Authorize(ArticlesPermissions.Article.Update)]
        public override async Task<ArticleDto> UpdateAsync(Guid id, CreateUpdateArticleDto input)
        {
            //var entity = await GetEntityByIdAsync(id);
            var entity = await _repository.GetAsync(id, false);
            ObjectMapper.Map(input, entity);

            entity = await _articleManager.UpdateAsync(entity);
            return ObjectMapper.Map<Article, ArticleDto>(entity);
        }

        public async Task<List<CatalogDto>> FindAllCatalogAsync()
        {
            var query = _repository.WithDetails();
            query = JoinPublicFilteredQuery(query);

            var catalogDtoQuery = query.GroupBy(c => c.Catalog.Title)
                .Select(c => new CatalogDto
                {
                    Title = c.Key,
                    ArticleCount = c.Count()
                });

            return await _asyncExecuter.ToListAsync(catalogDtoQuery);
        }

        public async Task<List<TagDto>> FindAllTagAsync()
        {
            var query = JoinPublicFilteredQuery(_repository);

            var tagDtoQuery = query.GroupBy(c => c.Tag)
                 .Select(c => new TagDto
                 {
                     Name = c.Key,
                     ArticleCount = c.Count()
                 });

            return await _asyncExecuter.ToListAsync(tagDtoQuery);
        }
    }
}
