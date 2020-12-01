using Simple.Abp.Articles.Dtos;
using Simple.Abp.Articles.Permissions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Linq;

namespace Simple.Abp.Articles
{
    public class CatalogAppService : 
        CrudAppService<
            Catalog, 
            CatalogDto, 
            Guid, 
            PagedAndSortedResultRequestDto, 
            CreateUpdateCatalogDto, 
            CreateUpdateCatalogDto>,
            ICatalogAppService
    {
        protected override string GetPolicyName { get; set; } = ArticlesPermissions.Catalog.Default;
        protected override string GetListPolicyName { get; set; } = ArticlesPermissions.Catalog.Default;
        protected override string CreatePolicyName { get; set; } = ArticlesPermissions.Catalog.Create;
        protected override string UpdatePolicyName { get; set; } = ArticlesPermissions.Catalog.Update;
        protected override string DeletePolicyName { get; set; } = ArticlesPermissions.Catalog.Delete;

        private readonly ICatalogRepository _repository;
        private readonly IArticleRepository _articleRepository;
        private readonly IAsyncQueryableExecuter _asyncExecuter;

        public CatalogAppService(ICatalogRepository repository,
            IArticleRepository articleRepository,
            IAsyncQueryableExecuter asyncExecuter) : base(repository)
        {
            _repository = repository;
            _articleRepository = articleRepository;
            _asyncExecuter = asyncExecuter;
        }

        private List<Catalog> FindChilds(Catalog parentCatalog, List<Catalog> catalogs)
        {
            var childs = catalogs.Where(c => c.ParentId == parentCatalog.Id).ToList();
            if (childs == null || childs.Count <= 0)
                return null;

            foreach (var child in childs)
            {
                if (child.Id == parentCatalog.Id)
                    continue;

                childs.AddRange(FindChilds(child, catalogs));
            }

            return childs;
        }

        private void FindChilds(CatalogDto parentCatalog, List<CatalogDto> catalogs)
        {
            var childs = catalogs.Where(c => c.ParentId == parentCatalog.Id).ToList();
            if (childs == null || childs.Count <= 0)
                return;

            foreach (var child in childs)
            {
                if (child.Id == parentCatalog.Id)
                    continue;

                FindChilds(child, catalogs);
            }

            parentCatalog.Childs = childs;
        }

        public async Task<List<CatalogDto>> GetTreeAsync()
        {
            var catalogEntities = await _repository.GetListAsync();
            var catalogs = ObjectMapper.Map<List<Catalog>, List<CatalogDto>>(catalogEntities);
           
            var parentCatalogs = catalogs.Where(c => c.ParentId == null).ToList();
            parentCatalogs.ForEach(c => FindChilds(c, catalogs));

            return parentCatalogs;
        }

        public async Task<List<CatalogDto>> GetExistArticleList()
        {
            var query = from c in _repository
                        join a in _articleRepository.WithPublicFilter() on c.Id equals a.CatalogId
                        group c by new { c.Id, c.ParentId, c.Title, c.Description } into g
                        select new CatalogDto
                        {
                            Id = g.Key.Id,
                            ParentId = g.Key.ParentId,
                            Title = g.Key.Title,
                            Description = g.Key.Description,
                            ArticleCount = g.Count()

                        } into s
                        where s.ArticleCount > 0
                        select s;

            return await _asyncExecuter.ToListAsync(query);
        }
    }
}
