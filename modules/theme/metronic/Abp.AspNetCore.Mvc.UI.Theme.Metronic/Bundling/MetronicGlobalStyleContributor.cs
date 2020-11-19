using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Abp.AspNetCore.Mvc.UI.Theme.Metronic.Bundling
{
    public class MetronicGlobalStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            //plugins.bundle.css
            context.Files.Add("/themes/css/plugins/plugins.bundle.css");
            context.Files.Add("/themes/css/style.bundle.min.css");

            context.Files.Add("/themes/css/layout/header/base/light.css");
            context.Files.Add("/themes/css/layout/header/menu/light.css");
            context.Files.Add("/themes/css/layout/brand/dark.css");
            context.Files.Add("/themes/css/layout/aside/dark.css");
        }
    }
}
