using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Simple.Abp.Articles;
using Simple.Abp.Blog.MultiTenancy;
using Volo.Abp.AuditLogging;
using Volo.Abp.Emailing;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;

namespace Simple.Abp.Blog
{
    [DependsOn(
        typeof(BlogDomainSharedModule),
        typeof(AbpAuditLoggingDomainModule),
        typeof(AbpIdentityDomainModule),
        typeof(AbpPermissionManagementDomainIdentityModule),
        typeof(AbpIdentityServerDomainModule),
        typeof(AbpPermissionManagementDomainIdentityServerModule),
        typeof(AbpArticlesDomainModule),
        typeof(AbpEmailingModule)
    )]
    public class BlogDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //Configure<AbpMultiTenancyOptions>(options =>
            //{
            //    options.IsEnabled = MultiTenancyConsts.IsEnabled;
            //});

#if DEBUG
            context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
        }
    }
}
