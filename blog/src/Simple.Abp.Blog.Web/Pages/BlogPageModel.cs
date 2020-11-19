using Simple.Abp.Blog.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Simple.Abp.Blog.Web.Pages
{
    public abstract class BlogPageModel : AbpPageModel
    {
        protected BlogPageModel()
        {
            LocalizationResourceType = typeof(BlogResource);
        }
    }
}