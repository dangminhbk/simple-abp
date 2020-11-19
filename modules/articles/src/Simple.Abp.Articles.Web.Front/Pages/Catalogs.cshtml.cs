using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simple.Abp.Articles.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Simple.Abp.Articles.Web.Front.Pages
{
    public class CatalogsModel : AbpPageModel
    {
        private readonly IArticleAppService _articleAppService;

        public List<CatalogDto> Catalogs { get; set; }

        public CatalogsModel(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            Catalogs = await _articleAppService.FindAllCatalogAsync();
            return Page();
        }
    }
}