using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account.Web;
using Volo.Abp.Modularity;

namespace Simple.Abp.Account.Web
{
    [DependsOn(
         typeof(SimpleAbpAccountWebModule),
         typeof(AbpAccountWebIdentityServerModule)
    )]
    public class SimpleAbpAccountWebIdentityServerModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            //context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            //{
            //    options.AddAssemblyResource(typeof(AccountResource), typeof(AbpAccountWebModule).Assembly);
            //});

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(SimpleAbpAccountWebIdentityServerModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //Configure<AbpVirtualFileSystemOptions>(options =>
            //{
            //    options.FileSets.AddEmbedded<AbpAccountWebModule>("Volo.Abp.Account.Web");
            //});

            //Configure<AbpNavigationOptions>(options =>
            //{
            //    options.MenuContributors.Add(new AbpAccountUserMenuContributor());
            //});

            //Configure<AbpToolbarOptions>(options =>
            //{
            //    options.Contributors.Add(new AccountModuleToolbarContributor());
            //});

            //Configure<RazorPagesOptions>(options =>
            //{
            //    options.Conventions.AuthorizePage("/Account/Manage");
            //});

            //context.Services.AddAutoMapperObjectMapper<AbpAccountWebModule>();
            //Configure<AbpAutoMapperOptions>(options =>
            //{
            //    options.AddProfile<AbpAccountWebAutoMapperProfile>(validate: true);
            //});
        }
    }
}
