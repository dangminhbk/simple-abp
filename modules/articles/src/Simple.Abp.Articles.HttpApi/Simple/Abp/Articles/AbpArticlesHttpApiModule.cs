using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Simple.Abp.Articles.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Simple.Abp.Articles
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpArticlesApplicationContractsModule)
    )]
    public class AbpArticlesHttpApiModule:AbpModule      
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpArticlesHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<ArticlesResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}
