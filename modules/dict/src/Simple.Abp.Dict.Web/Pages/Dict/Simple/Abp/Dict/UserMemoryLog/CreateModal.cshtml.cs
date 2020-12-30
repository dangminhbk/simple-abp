using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Dict;
using Simple.Abp.Dict.Dtos;
using Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.UserMemoryLog.ViewModels;

namespace Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.UserMemoryLog
{
    public class CreateModalModel : DictPageModel
    {
        [BindProperty]
        public CreateEditUserMemoryLogViewModel ViewModel { get; set; }

        private readonly IUserMemoryLogAppService _service;

        public CreateModalModel(IUserMemoryLogAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditUserMemoryLogViewModel, CreateUpdateUserMemoryLogDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}