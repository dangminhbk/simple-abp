using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Articles.Web.Front.Shared.Components.Bilibili
{
    public class BilibiliViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Shared/Components/Bilibili/Default.cshtml");
        }
    }
}
