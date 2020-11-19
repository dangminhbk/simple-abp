using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Dtos;
using Simple.Abp.Articles.Web.Pages.Articles.Tag.ViewModels;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Simple.Abp.Articles.Web.Pages.Articles.Tag
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateEditTagViewModel ViewModel { get; set; }

        private readonly ITagAppService _service;

        public CreateModalModel(ITagAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();

            var dto = ObjectMapper.Map<CreateEditTagViewModel, CreateUpdateTagDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}