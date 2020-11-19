using Simple.Abp.Articles.Dtos;
using Simple.Abp.Articles.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

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
        
        public CatalogAppService(ICatalogRepository repository) : base(repository)
        {
            _repository = repository;
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
    }
}
