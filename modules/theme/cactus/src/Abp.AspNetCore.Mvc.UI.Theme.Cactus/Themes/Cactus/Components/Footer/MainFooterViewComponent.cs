using Abp.AspNetCore.Mvc.UI.Theme.Cactus;
using Abp.AspNetCore.Mvc.UI.Theme.Cactus.Themes.Cactus.Components.Footer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Settings;
using Volo.Abp.UI.Navigation;

namespace Abp.AspNetCore.Mvc.UI.Theme.Metronic.Themes.Metronic.Components.Footer
{
    public class MainFooterViewComponent : AbpViewComponent
    {
        private readonly IMenuManager _menuManager;
        public MainFooterViewComponent(IMenuManager menuManager)
        {
            _menuManager = menuManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menu = await _menuManager.GetAsync(CactusMenus.Footer);

            var model = new FooterViewModel();
            model.Menu = menu;
            return View("~/Themes/Cactus/Components/Footer/Default.cshtml", model);
        }
    }
}
