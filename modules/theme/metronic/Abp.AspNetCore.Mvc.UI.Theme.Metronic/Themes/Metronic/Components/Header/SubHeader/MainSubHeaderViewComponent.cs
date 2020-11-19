using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.AspNetCore.Mvc.UI.Theme.Metronic.Themes.Metronic.Components.Header.SubHeader
{
    public class MainSubHeaderViewComponent: AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View($"~/Themes/Metronic/Components/Header/SubHeader/Default.cshtml");
        }
    }
}
