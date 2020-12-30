using Simple.Abp.Dict.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Simple.Abp.Dict.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class DictPageModel : AbpPageModel
    {
        protected DictPageModel()
        {
            LocalizationResourceType = typeof(DictResource);
            ObjectMapperContext = typeof(DictWebModule);
        }
    }
}