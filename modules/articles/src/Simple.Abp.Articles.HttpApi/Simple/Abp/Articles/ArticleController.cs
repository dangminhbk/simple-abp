using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Articles
{
    [RemoteService]
    [Area("Articles")]
    [ControllerName("Article")]
    [Route("api/article")]
    public class ArticleController : AbpController, IArticleAppService
    {
        private readonly IArticleAppService _articleAppService;
        public ArticleController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }

        [HttpPost]
        public Task<ArticleDto> CreateAsync(CreateUpdateArticleDto input)
        {
            return _articleAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _articleAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ArticleDto> GetAsync(Guid id)
        {
            return _articleAppService.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<ArticleDto>> GetListAsync(ArticlePagedRequestDto input)
        {
            return _articleAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("get-public/{id}")]
        public Task<ArticleDto> GetPublicAsync(Guid id)
        {
            return _articleAppService.GetPublicAsync(id);
        }

        [HttpGet]
        [Route("get-public-seo/{seoPath}")]
        public Task<ArticleDto> GetPublicBySEOAsync(string seoPath)
        {
            if (!seoPath.IsNullOrWhiteSpace())
                seoPath = HttpUtility.UrlDecode(seoPath);

            return _articleAppService.GetPublicBySEOAsync(seoPath);
        }

        [HttpGet]
        [Route("get-public")]
        public Task<PagedResultDto<ArticleDto>> GetPublicListAsync(ArticlePagedRequestDto request)
        {
            return _articleAppService.GetPublicListAsync(request);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<ArticleDto> UpdateAsync(Guid id, CreateUpdateArticleDto input)
        {
            return _articleAppService.UpdateAsync(id, input);
        }
    }
}
