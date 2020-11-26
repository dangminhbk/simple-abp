using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles;
using Simple.Abp.Articles.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Simple.Abp.Blog.Web.Front.Pages
{
    public class IndexModel : AbpPageModel
    {
        public List<ArticleDto> Articles { get; set; }


        private readonly IArticleAppService _articleAppService;

        public IndexModel(IArticleAppService articleAppService) 
        {
            _articleAppService = articleAppService;
            Articles = new List<ArticleDto>();
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            ArticlePagedRequestDto request = new ArticlePagedRequestDto();
            request.MaxResultCount = 5;
            var pageResult = await _articleAppService.GetPublicListAsync(request);
            if (pageResult.Items != null
               && pageResult.Items.Count > 0)
                Articles = pageResult.Items.ToList();

            // TODO Projects

            return Page();
        }
    }
}
