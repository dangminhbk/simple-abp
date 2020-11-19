using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Account.Web;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Simple.Abp.Account.Web
{
    [DependsOn(
        typeof(AbpAccountWebModule)
        )]
    public class SimpleAbpAccountWebModule:AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            //context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            //{
            //    options.AddAssemblyResource(typeof(AccountResource), typeof(AbpAccountWebModule).Assembly);
            //});

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(SimpleAbpAccountWebModule).Assembly);
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
