using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Dtos;
using Simple.Abp.Articles.Web.Pages.Articles.Catalog.ViewModels;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Simple.Abp.Articles.Catalog
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditCatalogViewModel ViewModel { get; set; }

        private readonly ICatalogAppService _service;

        public EditModalModel(ICatalogAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<CatalogDto, CreateEditCatalogViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditCatalogViewModel, CreateUpdateCatalogDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}