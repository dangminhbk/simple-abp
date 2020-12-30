using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Dict;
using Simple.Abp.Dict.Dtos;
using Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.UserAssignment.ViewModels;

namespace Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.UserAssignment
{
    public class EditModalModel : DictPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditUserAssignmentViewModel ViewModel { get; set; }

        private readonly IUserAssignmentAppService _service;

        public EditModalModel(IUserAssignmentAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<UserAssignmentDto, CreateEditUserAssignmentViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditUserAssignmentViewModel, CreateUpdateUserAssignmentDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}