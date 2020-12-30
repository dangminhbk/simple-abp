using System;
using Simple.Abp.Dict.Permissions;
using Simple.Abp.Dict.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Dict
{
    public class UserMemoryLogAppService : CrudAppService<UserMemoryLog, UserMemoryLogDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateUserMemoryLogDto, CreateUpdateUserMemoryLogDto>,
        IUserMemoryLogAppService
    {
        protected override string GetPolicyName { get; set; } = DictPermissions.UserMemoryLog.Default;
        protected override string GetListPolicyName { get; set; } = DictPermissions.UserMemoryLog.Default;
        protected override string CreatePolicyName { get; set; } = DictPermissions.UserMemoryLog.Create;
        protected override string UpdatePolicyName { get; set; } = DictPermissions.UserMemoryLog.Update;
        protected override string DeletePolicyName { get; set; } = DictPermissions.UserMemoryLog.Delete;

        private readonly IUserMemoryLogRepository _repository;
        
        public UserMemoryLogAppService(IUserMemoryLogRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
