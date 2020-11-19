using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Dtos;
using Simple.Abp.Articles.Web.Pages.Articles.Article.ViewModels;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Simple.Abp.Articles.Web.Pages.Articles.Article
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditArticleViewModel ViewModel { get; set; }

        private readonly IArticleAppService _service;

        public EditModalModel(IArticleAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<ArticleDto, CreateEditArticleViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditArticleViewModel, CreateUpdateArticleDto>(ViewModel);
            var result = await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}