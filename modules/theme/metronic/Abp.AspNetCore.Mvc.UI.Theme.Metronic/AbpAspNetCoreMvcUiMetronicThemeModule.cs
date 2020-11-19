using Abp.AspNetCore.Mvc.UI.Theme.Metronic.Localization;
using Abp.AspNetCore.Mvc.UI.Theme.Metronic.Bundling;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Localization.Resources.AbpUi;

namespace Abp.AspNetCore.Mvc.UI.Theme.Metronic
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcUiThemeSharedModule)
       )]
    public class AbpAspNetCoreMvcUiMetronicThemeModule:AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(
                    typeof(AbpAspNetCoreMvcUiMetronicThemeModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpThemingOptions>(options =>
            {
                options.Themes.Add<MetronicTheme>();
                options.DefaultThemeName = MetronicTheme.Name;
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAspNetCoreMvcUiMetronicThemeModule>
                    ("Abp.AspNetCore.Mvc.UI.Theme.Metronic");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<MetronicResource>("en")
                    .AddVirtualJson("/Localization/Metronic");
            });

            Configure<AbpBundlingOptions>(options =>
            {
                options.StyleBundles.Add(MetronicThemeBundles.Styles.Global, bundle =>
                {
                    bundle//.AddBaseBundles("Global")
                            .AddContributors(typeof(MetronicGlobalStyleContributor));
                });

                options.ScriptBundles.Add(MetronicThemeBundles.Scripts.Global, bundle =>
                {
                    bundle.AddBaseBundles("Global")
                          .AddContributors(typeof(MetronicGlobalScriptContributor));
                });

            });
        }
    }
}
