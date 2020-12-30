using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Dict;
using Simple.Abp.Dict.Dtos;
using Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.UserMemoryLog.ViewModels;

namespace Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.UserMemoryLog
{
    public class EditModalModel : DictPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditUserMemoryLogViewModel ViewModel { get; set; }

        private readonly IUserMemoryLogAppService _service;

        public EditModalModel(IUserMemoryLogAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<UserMemoryLogDto, CreateEditUserMemoryLogViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditUserMemoryLogViewModel, CreateUpdateUserMemoryLogDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}