using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Dict;
using Simple.Abp.Dict.Dtos;
using Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.Catalog.ViewModels;

namespace Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.Catalog
{
    public class CreateModalModel : DictPageModel
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