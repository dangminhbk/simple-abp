using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Dict;
using Simple.Abp.Dict.Dtos;
using Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.UserSelectWord.ViewModels;

namespace Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.UserSelectWord
{
    public class EditModalModel : DictPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditUserSelectWordViewModel ViewModel { get; set; }

        private readonly IUserSelectWordAppService _service;

        public EditModalModel(IUserSelectWordAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<UserSelectWordDto, CreateEditUserSelectWordViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditUserSelectWordViewModel, CreateUpdateUserSelectWordDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}