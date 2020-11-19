using Simple.Abp.Articles.Dtos;
using Simple.Abp.Articles.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Articles
{
    public class TagAppService :
        CrudAppService<
            Tag,
            TagDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateTagDto,
            CreateUpdateTagDto>,
        ITagAppService
    {
        protected override string GetPolicyName { get; set; } = ArticlesPermissions.Tag.Default;
        protected override string GetListPolicyName { get; set; } = ArticlesPermissions.Tag.Default;
        protected override string CreatePolicyName { get; set; } = ArticlesPermissions.Tag.Create;
        protected override string UpdatePolicyName { get; set; } = ArticlesPermissions.Tag.Update;
        protected override string DeletePolicyName { get; set; } = ArticlesPermissions.Tag.Delete;

        private readonly ITagRepository _repository;

        public TagAppService(ITagRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<TagDto>> GetAllAsync()
        {
            var entities = await _repository.GetListAsync();
            var modelList = ObjectMapper.Map<List<Tag>, List<TagDto>>(entities);
            return modelList;
        }
    }
}
