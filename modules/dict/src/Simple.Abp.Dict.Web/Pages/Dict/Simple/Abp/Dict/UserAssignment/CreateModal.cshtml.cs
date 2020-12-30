using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Dict;
using Simple.Abp.Dict.Dtos;
using Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.UserAssignment.ViewModels;

namespace Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.UserAssignment
{
    public class CreateModalModel : DictPageModel
    {
        [BindProperty]
        public CreateEditUserAssignmentViewModel ViewModel { get; set; }

        private readonly IUserAssignmentAppService _service;

        public CreateModalModel(IUserAssignmentAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditUserAssignmentViewModel, CreateUpdateUserAssignmentDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}