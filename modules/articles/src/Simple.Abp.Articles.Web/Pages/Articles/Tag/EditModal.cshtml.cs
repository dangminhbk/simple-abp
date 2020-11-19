using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Dtos;
using Simple.Abp.Articles.Web.Pages.Articles.Tag.ViewModels;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Simple.Abp.Articles.Web.Pages.Articles.Tag
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditTagViewModel ViewModel { get; set; }

        private readonly ITagAppService _service;

        public EditModalModel(ITagAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<TagDto, CreateEditTagViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();
            var dto = ObjectMapper.Map<CreateEditTagViewModel, CreateUpdateTagDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}