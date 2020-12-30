using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Dict;
using Simple.Abp.Dict.Dtos;
using Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.UserCatalogMapping.ViewModels;

namespace Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.UserCatalogMapping
{
    public class CreateModalModel : DictPageModel
    {
        [BindProperty]
        public CreateEditUserCatalogMappingViewModel ViewModel { get; set; }

        private readonly IUserCatalogMappingAppService _service;

        public CreateModalModel(IUserCatalogMappingAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditUserCatalogMappingViewModel, CreateUpdateUserCatalogMappingDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}