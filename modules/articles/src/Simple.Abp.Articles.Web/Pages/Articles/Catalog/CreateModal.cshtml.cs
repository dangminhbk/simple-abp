using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Dtos;
using Simple.Abp.Articles.Web.Pages.Articles.Catalog.ViewModels;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Simple.Abp.Articles.Catalog
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateEditCatalogViewModel ViewModel { get; set; }

        private readonly ICatalogAppService _service;

        public CreateModalModel(ICatalogAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditCatalogViewModel, CreateUpdateCatalogDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}