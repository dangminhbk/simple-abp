using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Blog.Web.Front.Shared.Components.Project
{
    public class ProjectViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Shared/Components/Project/Default.cshtml");
        }
    }
}
