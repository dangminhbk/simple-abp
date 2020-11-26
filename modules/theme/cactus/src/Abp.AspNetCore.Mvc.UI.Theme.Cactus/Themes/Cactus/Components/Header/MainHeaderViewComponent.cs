using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.UI.Navigation;

namespace Abp.AspNetCore.Mvc.UI.Theme.Metronic.Themes.Metronic.Components.Header
{
    public class MainHeaderViewComponent: AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/Cactus/Components/Header/Default.cshtml");
        }
    }
}
