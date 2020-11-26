using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Abp.AspNetCore.Mvc.UI.Theme.Cactus
{
    [DependsOn(
       typeof(AbpAspNetCoreMvcUiThemeSharedModule)
      )]
    public class AbpAspNetCoreMvcUiCactusThemeModule:AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(
                    typeof(AbpAspNetCoreMvcUiCactusThemeModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpThemingOptions>(options =>
            {
                options.Themes.Add<CactusTheme>();
                options.DefaultThemeName = CactusTheme.Name;
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAspNetCoreMvcUiCactusThemeModule>
                    ("Abp.AspNetCore.Mvc.UI.Theme.Cactus");
            });
        }

    }
}
