using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Dtos;
using Simple.Abp.Articles.Web.Pages.Articles.Article.ViewModels;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Simple.Abp.Articles.Web.Pages.Articles.Article
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateEditArticleViewModel ViewModel { get; set; }

        private readonly IArticleAppService _service;

        public CreateModalModel(IArticleAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditArticleViewModel, CreateUpdateArticleDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}