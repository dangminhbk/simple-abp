using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Dict;
using Simple.Abp.Dict.Dtos;
using Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.UserSelectWord.ViewModels;

namespace Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.UserSelectWord
{
    public class CreateModalModel : DictPageModel
    {
        [BindProperty]
        public CreateEditUserSelectWordViewModel ViewModel { get; set; }

        private readonly IUserSelectWordAppService _service;

        public CreateModalModel(IUserSelectWordAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditUserSelectWordViewModel, CreateUpdateUserSelectWordDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}