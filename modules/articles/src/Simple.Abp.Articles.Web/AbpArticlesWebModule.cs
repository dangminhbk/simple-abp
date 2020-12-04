using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Simple.Abp.Articles.Localization;
using Simple.Abp.Articles.Permissions;
using Simple.Abp.Articles.Web.Navigation;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace Simple.Abp.Articles.Web
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpArticlesHttpApiModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedModule)
    )]
    public class AbpArticlesWebModule:AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(ArticlesResource), typeof(AbpArticlesWebModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpArticlesWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new AbpArticlesMenuContributor());
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpArticlesWebModule>();
            });

            context.Services.AddAutoMapperObjectMapper<AbpArticlesWebModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpArticlesWebModule>();
            });

            Configure<RazorPagesOptions>(options =>
            {
                options.Conventions.AuthorizePage("/Articles/Article/Index", ArticlesPermissions.Article.Default);
                options.Conventions.AuthorizePage("/Articles/Article/CreateModal", ArticlesPermissions.Article.Create);
                options.Conventions.AuthorizePage("/Articles/Article/EditModal", ArticlesPermissions.Article.Update);
                options.Conventions.AuthorizePage("/Articles/Catalog/Index", ArticlesPermissions.Catalog.Default);
                options.Conventions.AuthorizePage("/Articles/Catalog/CreateModal", ArticlesPermissions.Catalog.Create);
                options.Conventions.AuthorizePage("/Articles/Catalog/EditModal", ArticlesPermissions.Catalog.Update);
                options.Conventions.AuthorizePage("/Articles/Tag/Index", ArticlesPermissions.Tag.Default);
                options.Conventions.AuthorizePage("/Articles/Tag/CreateModal", ArticlesPermissions.Tag.Create);
                options.Conventions.AuthorizePage("/Articles/Tag/EditModal", ArticlesPermissions.Tag.Update);
            });
        }
    }
}
