using System;
using Simple.Abp.Dict.Permissions;
using Simple.Abp.Dict.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Dict
{
    public class CatalogWordMappingAppService : CrudAppService<CatalogWordMapping, CatalogWordMappingDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCatalogWordMappingDto, CreateUpdateCatalogWordMappingDto>,
        ICatalogWordMappingAppService
    {
        protected override string GetPolicyName { get; set; } = DictPermissions.CatalogWordMapping.Default;
        protected override string GetListPolicyName { get; set; } = DictPermissions.CatalogWordMapping.Default;
        protected override string CreatePolicyName { get; set; } = DictPermissions.CatalogWordMapping.Create;
        protected override string UpdatePolicyName { get; set; } = DictPermissions.CatalogWordMapping.Update;
        protected override string DeletePolicyName { get; set; } = DictPermissions.CatalogWordMapping.Delete;

        private readonly ICatalogWordMappingRepository _repository;
        
        public CatalogWordMappingAppService(ICatalogWordMappingRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
