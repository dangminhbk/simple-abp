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
    public class TagsModel : AbpPageModel
    {
        private readonly ITagAppService _tagAppService;

        public List<TagDto> Tags { get; set; }

        public TagsModel(ITagAppService tagAppService)
        {
            _tagAppService = tagAppService;
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            Tags = await _tagAppService.GetExistArticleList();
            return Page();
        }

    }
}
