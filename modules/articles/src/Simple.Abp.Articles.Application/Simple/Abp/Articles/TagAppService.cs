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
        private readonly IArticleRepository _articlerepository;
        private readonly IAsyncQueryableExecuter _asyncExecuter;

        public TagAppService(ITagRepository repository,
            IArticleRepository articlerepository,
            IAsyncQueryableExecuter asyncExecuter) : base(repository)
        {
            _repository = repository;
            _articlerepository = articlerepository;
            _asyncExecuter = asyncExecuter;
        }

        public async Task<List<TagDto>> GetAllAsync()
        {
            var entities = await _repository.GetListAsync();
            var modelList = ObjectMapper.Map<List<Tag>, List<TagDto>>(entities);
            return modelList;
        }

        public async Task<List<TagDto>> GetExistArticleList()
        {
            var query = from c in _repository
                        join a in _articlerepository.WithPublicFilter() on c.Name equals a.Tag
                        group c by new { c.Id, c.Name } into g
                        select new TagDto
                        {
                            Id = g.Key.Id,
                            Name = g.Key.Name,
                            ArticleCount = g.Count()
                        } into s
                        where s.ArticleCount > 0
                        select s;

            return await _asyncExecuter.ToListAsync(query);
        }
    }
}
