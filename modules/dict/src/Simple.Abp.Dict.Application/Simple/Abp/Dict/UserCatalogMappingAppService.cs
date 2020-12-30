using System;
using Simple.Abp.Dict.Permissions;
using Simple.Abp.Dict.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Dict
{
    public class UserCatalogMappingAppService : CrudAppService<UserCatalogMapping, UserCatalogMappingDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateUserCatalogMappingDto, CreateUpdateUserCatalogMappingDto>,
        IUserCatalogMappingAppService
    {
        protected override string GetPolicyName { get; set; } = DictPermissions.UserCatalogMapping.Default;
        protected override string GetListPolicyName { get; set; } = DictPermissions.UserCatalogMapping.Default;
        protected override string CreatePolicyName { get; set; } = DictPermissions.UserCatalogMapping.Create;
        protected override string UpdatePolicyName { get; set; } = DictPermissions.UserCatalogMapping.Update;
        protected override string DeletePolicyName { get; set; } = DictPermissions.UserCatalogMapping.Delete;

        private readonly IUserCatalogMappingRepository _repository;
        
        public UserCatalogMappingAppService(IUserCatalogMappingRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
