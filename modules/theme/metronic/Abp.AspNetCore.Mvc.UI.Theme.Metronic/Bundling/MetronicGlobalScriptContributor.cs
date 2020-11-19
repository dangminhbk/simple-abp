using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Abp.AspNetCore.Mvc.UI.Theme.Metronic.Bundling
{

    public class MetronicGlobalScriptContributor: BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            // plugins
            context.Files.Add("/themes/js/plugins/perfect-scrollbar.js");

            // components
            context.Files.Add("/themes/js/components/util.js");
            context.Files.Add("/themes/js/components/app.js");
            context.Files.Add("/themes/js/components/card.js");
            context.Files.Add("/themes/js/components/cookie.js");
            context.Files.Add("/themes/js/components/dialog.js");
            context.Files.Add("/themes/js/components/header.js");
            context.Files.Add("/themes/js/components/image-input.js");
            context.Files.Add("/themes/js/components/menu.js");
            context.Files.Add("/themes/js/components/offcanvas.js");
            context.Files.Add("/themes/js/components/scrolltop.js");
            context.Files.Add("/themes/js/components/toggle.js");

            // Metronic layout base js
            context.Files.Add("/themes/js/layout/base/aside.js");
            context.Files.Add("/themes/js/layout/base/aside-menu.js");
            context.Files.Add("/themes/js/layout/base/aside-toggle.js");
            context.Files.Add("/themes/js/layout/base/brand.js");
            context.Files.Add("/themes/js/layout/base/content.js");
            context.Files.Add("/themes/js/layout/base/footer.js");
            context.Files.Add("/themes/js/layout/base/header.js");
            context.Files.Add("/themes/js/layout/base/header-menu.js");
            context.Files.Add("/themes/js/layout/base/header-topbar.js");
            context.Files.Add("/themes/js/layout/base/sticky-card.js");
            context.Files.Add("/themes/js/layout/base/stretched-card.js");
            context.Files.Add("/themes/js/layout/base/subheader.js");

            // Metronic layout extended js
            context.Files.Add("/themes/js/layout/extended/chat.js");
            context.Files.Add("/themes/js/layout/extended/demo-panel.js");
            context.Files.Add("/themes/js/layout/extended/examples.js");
            context.Files.Add("/themes/js/layout/extended/quick-actions.js");
            context.Files.Add("/themes/js/layout/extended/quick-cart.js");
            context.Files.Add("/themes/js/layout/extended/quick-notifications.js");
            context.Files.Add("/themes/js/layout/extended/quick-panel.js");
            context.Files.Add("/themes/js/layout/extended/quick-search.js");
            context.Files.Add("/themes/js/layout/extended/quick-user.js");
            context.Files.Add("/themes/js/layout/extended/scrolltop.js");
            context.Files.Add("/themes/js/layout/extended/search.js");

            context.Files.Add("/themes/js/layout/initialize.js");
        }
    }
}
