using EasyAbp.Abp.SettingUi;
using Simple.Abp.Articles;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.PermissionManagement;

namespace Simple.Abp.Blog
{
    [DependsOn(
        typeof(BlogDomainSharedModule),
        typeof(AbpAccountApplicationContractsModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpPermissionManagementApplicationContractsModule),
        typeof(AbpArticlesApplicationContractsModule),
        typeof(SettingUiApplicationContractsModule),
        typeof(AbpObjectExtendingModule)
    )]
    public class BlogApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            BlogDtoExtensions.Configure();
        }
    }
}
