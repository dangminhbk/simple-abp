using System;
using Simple.Abp.Dict.Permissions;
using Simple.Abp.Dict.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Dict
{
    public class UserAssignmentAppService : CrudAppService<UserAssignment, UserAssignmentDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateUserAssignmentDto, CreateUpdateUserAssignmentDto>,
        IUserAssignmentAppService
    {
        protected override string GetPolicyName { get; set; } = DictPermissions.UserAssignment.Default;
        protected override string GetListPolicyName { get; set; } = DictPermissions.UserAssignment.Default;
        protected override string CreatePolicyName { get; set; } = DictPermissions.UserAssignment.Create;
        protected override string UpdatePolicyName { get; set; } = DictPermissions.UserAssignment.Update;
        protected override string DeletePolicyName { get; set; } = DictPermissions.UserAssignment.Delete;

        private readonly IUserAssignmentRepository _repository;
        
        public UserAssignmentAppService(IUserAssignmentRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
