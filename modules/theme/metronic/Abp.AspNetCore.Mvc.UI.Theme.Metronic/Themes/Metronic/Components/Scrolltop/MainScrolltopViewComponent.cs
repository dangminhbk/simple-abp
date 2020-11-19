using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.AspNetCore.Mvc.UI.Theme.Metronic.Themes.Metronic.Components.Scrolltop
{
    public class MainScrolltopViewComponent: AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/Metronic/Components/Scrolltop/Default.cshtml");
        }
    }
}
