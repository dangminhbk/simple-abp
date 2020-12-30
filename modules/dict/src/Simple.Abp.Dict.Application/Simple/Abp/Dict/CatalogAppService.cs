using System;
using Simple.Abp.Dict.Permissions;
using Simple.Abp.Dict.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Dict
{
    public class CatalogAppService : CrudAppService<Catalog, CatalogDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCatalogDto, CreateUpdateCatalogDto>,
        ICatalogAppService
    {
        protected override string GetPolicyName { get; set; } = DictPermissions.Catalog.Default;
        protected override string GetListPolicyName { get; set; } = DictPermissions.Catalog.Default;
        protected override string CreatePolicyName { get; set; } = DictPermissions.Catalog.Create;
        protected override string UpdatePolicyName { get; set; } = DictPermissions.Catalog.Update;
        protected override string DeletePolicyName { get; set; } = DictPermissions.Catalog.Delete;

        private readonly ICatalogRepository _repository;
        
        public CatalogAppService(ICatalogRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
