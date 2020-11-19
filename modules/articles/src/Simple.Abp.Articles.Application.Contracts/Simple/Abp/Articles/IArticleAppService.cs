using Simple.Abp.Articles.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Articles
{
    public interface IArticleAppService :
        ICrudAppService< 
            ArticleDto, 
            Guid,
            ArticlePagedRequestDto,
            CreateUpdateArticleDto,
            CreateUpdateArticleDto>
    {
        Task<PagedResultDto<ArticleDto>> GetPublicListAsync(ArticlePagedRequestDto request);

        Task<ArticleDto> GetPublicAsync(Guid id);

        Task<ArticleDto> GetPublicBySEOAsync(string seoPath);

        Task<List<CatalogDto>> FindAllCatalogAsync();

        Task<List<TagDto>> FindAllTagAsync();
    }
}