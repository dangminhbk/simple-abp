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
        private readonly ICatalogAppService _catalogAppService;

        public List<CatalogDto> Catalogs { get; set; }

        public CatalogsModel(ICatalogAppService catalogAppService)
        {
            _catalogAppService = catalogAppService;
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            Catalogs = await _catalogAppService.GetExistArticleList();
            return Page();
        }
    }
}
