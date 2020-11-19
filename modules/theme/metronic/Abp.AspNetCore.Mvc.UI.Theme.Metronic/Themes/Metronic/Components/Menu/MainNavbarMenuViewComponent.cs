using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.UI.Navigation;

namespace Abp.AspNetCore.Mvc.UI.Theme.Metronic.Themes.Metronic.Components.Menu
{
    public class MainNavbarMenuViewComponent : AbpViewComponent
    {
        private readonly IMenuManager _menuManager;
        private readonly MetronicOptions _metronicOptions;
        public MainNavbarMenuViewComponent(IMenuManager menuManager,
            IOptions<MetronicOptions> metronicOptions)
        {
            _menuManager = menuManager;
            _metronicOptions = metronicOptions.Value;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string standardMenu = StandardMenus.Main;
            if (_metronicOptions != null)
                standardMenu = _metronicOptions.StandardMenu ?? standardMenu;

            var menu = await _menuManager.GetAsync(standardMenu);
            return View("~/Themes/Metronic/Components/Menu/Default.cshtml", menu);
        }
    }
}
