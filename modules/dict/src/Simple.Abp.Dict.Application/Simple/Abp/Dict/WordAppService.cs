using System;
using Simple.Abp.Dict.Permissions;
using Simple.Abp.Dict.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Dict
{
    public class WordAppService : CrudAppService<Word, WordDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateWordDto, CreateUpdateWordDto>,
        IWordAppService
    {
        protected override string GetPolicyName { get; set; } = DictPermissions.Word.Default;
        protected override string GetListPolicyName { get; set; } = DictPermissions.Word.Default;
        protected override string CreatePolicyName { get; set; } = DictPermissions.Word.Create;
        protected override string UpdatePolicyName { get; set; } = DictPermissions.Word.Update;
        protected override string DeletePolicyName { get; set; } = DictPermissions.Word.Delete;

        private readonly IWordRepository _repository;
        
        public WordAppService(IWordRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
