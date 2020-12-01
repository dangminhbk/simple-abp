using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simple.Abp.Articles;
using Simple.Abp.Articles.Dtos;
using Simple.Abp.Articles.Web.Front.Shared.Components.Pagination;

namespace Simple.Abp.Blog.Web.Front.Pages
{
    public class BilibiliModel : PageModel
    {
        
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public string Filter { get; set; }

        public PaginationViewModel PaginationViewModel { get; set; }

        /// <summary>
        /// bilibili
        /// </summary>
        public List<ArticleDto> Videos { get; set; }

        private readonly IArticleAppService _articleAppService;

        public BilibiliModel(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
            Videos = new List<ArticleDto>();
        }
        public virtual async Task<IActionResult> OnGetAsync()
        {
            ArticlePagedRequestDto request = new ArticlePagedRequestDto();
            request.InitSkipCount(PageIndex);
            request.Filter = Filter;
            request.CatalogTitle = "bilibili";

            var pageResult = await _articleAppService.GetPublicListAsync(request);
            if (pageResult == null)
                return Page();

            Videos = pageResult.Items.ToList();

            string urlTemplate = "/bilibili/page/{pageindex}";
            if (!Filter.IsNullOrWhiteSpace())
                urlTemplate += $"?filter={Filter}";

            PaginationViewModel = new PaginationViewModel(PageIndex,
                request.MaxResultCount, pageResult.TotalCount, urlTemplate);

            return Page();
        }
    }
}
