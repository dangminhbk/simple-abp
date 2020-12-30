using Simple.Abp.Dict.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Simple.Abp.Dict.Pages
{
    public abstract class DictPageModel : AbpPageModel
    {
        protected DictPageModel()
        {
            LocalizationResourceType = typeof(DictResource);
        }
    }
}