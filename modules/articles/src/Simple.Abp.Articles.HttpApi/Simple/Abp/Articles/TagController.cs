using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Articles
{
    [RemoteService]
    [Area("Articles")]
    [ControllerName("ArticleTag")]
    [Route("api/article-tag")]
    public class TagController : AbpController, ITagAppService
    {

        private readonly ITagAppService _tagAppService;
        public TagController(ITagAppService tagAppService)
        {
            _tagAppService = tagAppService;
        }
        [HttpPost]
        public Task<TagDto> CreateAsync(CreateUpdateTagDto input)
        {
            return _tagAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _tagAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("get-all")]
        public Task<List<TagDto>> GetAllAsync()
        {
            return _tagAppService.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public Task<TagDto> GetAsync(Guid id)
        {
            return _tagAppService.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<TagDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return _tagAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<TagDto> UpdateAsync(Guid id, CreateUpdateTagDto input)
        {
            return _tagAppService.UpdateAsync(id, input);
        }
    }
}
