using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.AspNetCore.Mvc.UI.Theme.Metronic.Themes.Metronic.Components.Header
{
    public class MainHeaderViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View($"~/Themes/Metronic/Components/Header/Default.cshtml");
        }
    }
}
