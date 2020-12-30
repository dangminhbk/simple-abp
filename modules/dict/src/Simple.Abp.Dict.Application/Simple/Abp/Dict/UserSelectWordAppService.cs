using System;
using Simple.Abp.Dict.Permissions;
using Simple.Abp.Dict.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Dict
{
    public class UserSelectWordAppService : CrudAppService<UserSelectWord, UserSelectWordDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateUserSelectWordDto, CreateUpdateUserSelectWordDto>,
        IUserSelectWordAppService
    {
        protected override string GetPolicyName { get; set; } = DictPermissions.UserSelectWord.Default;
        protected override string GetListPolicyName { get; set; } = DictPermissions.UserSelectWord.Default;
        protected override string CreatePolicyName { get; set; } = DictPermissions.UserSelectWord.Create;
        protected override string UpdatePolicyName { get; set; } = DictPermissions.UserSelectWord.Update;
        protected override string DeletePolicyName { get; set; } = DictPermissions.UserSelectWord.Delete;

        private readonly IUserSelectWordRepository _repository;
        
        public UserSelectWordAppService(IUserSelectWordRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
