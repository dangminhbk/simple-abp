using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.AspNetCore.Mvc.UI.Theme.Metronic.Themes.Metronic.Components.Brand
{
    public class MainNavbarBrandViewComponent: AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/Metronic/Components/Brand/Default.cshtml");
        }
    }
}
