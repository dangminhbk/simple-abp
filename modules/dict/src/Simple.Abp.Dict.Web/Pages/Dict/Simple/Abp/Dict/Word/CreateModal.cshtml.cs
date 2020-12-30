using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Dict;
using Simple.Abp.Dict.Dtos;
using Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.Word.ViewModels;

namespace Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.Word
{
    public class CreateModalModel : DictPageModel
    {
        [BindProperty]
        public CreateEditWordViewModel ViewModel { get; set; }

        private readonly IWordAppService _service;

        public CreateModalModel(IWordAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditWordViewModel, CreateUpdateWordDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}