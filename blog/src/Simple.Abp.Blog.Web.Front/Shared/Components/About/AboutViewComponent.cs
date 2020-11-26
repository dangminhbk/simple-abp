using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Blog.Web.Front.Shared.Components.About
{
    public class AboutViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Shared/Components/About/Default.cshtml");
        }
    }
}
