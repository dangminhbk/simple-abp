using Localization.Resources.AbpUi;
using Simple.Abp.Articles;
using Simple.Abp.Blog.Localization;
using Simple.Abp.TencentCos;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;

namespace Simple.Abp.Blog
{
    [DependsOn(
        typeof(BlogApplicationContractsModule),
        typeof(AbpAccountHttpApiModule),
        typeof(AbpIdentityHttpApiModule),
        typeof(AbpPermissionManagementHttpApiModule),
        typeof(AbpArticlesHttpApiModule),
        typeof(SimpleAbpTencentCosModule)
        )]
    public class BlogHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureLocalization();
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<BlogResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}
