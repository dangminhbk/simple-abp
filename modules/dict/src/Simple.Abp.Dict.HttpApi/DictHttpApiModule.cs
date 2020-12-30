using Localization.Resources.AbpUi;
using Simple.Abp.Dict.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Simple.Abp.Dict
{
    [DependsOn(
        typeof(DictApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class DictHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(DictHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<DictResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
