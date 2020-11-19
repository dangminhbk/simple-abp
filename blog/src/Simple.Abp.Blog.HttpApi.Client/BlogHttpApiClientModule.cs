using Microsoft.Extensions.DependencyInjection;
using Simple.Abp.Articles;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Simple.Abp.Blog
{
    [DependsOn(
        typeof(BlogApplicationContractsModule),
        typeof(AbpAccountHttpApiClientModule),
        typeof(AbpIdentityHttpApiClientModule),
        typeof(AbpPermissionManagementHttpApiClientModule),
        typeof(AbpArticlesHttpApiClientModule)
    )]
    public class BlogHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(BlogApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
