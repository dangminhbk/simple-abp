using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Simple.Abp.Articles.Web.Front
{
    [DependsOn(
      typeof(AbpAutoMapperModule),
      typeof(AbpAspNetCoreMvcUiModule),
      typeof(AbpArticlesHttpApiModule),
      typeof(AbpAspNetCoreMvcUiThemeSharedModule)
    )]
    public class AbpArticlesWebFrontModule:AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            //context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            //{
            //    options.AddAssemblyResource(typeof(IdentityResource), typeof(AbpIdentityWebModule).Assembly);
            //});

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpArticlesWebFrontModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //Configure<AbpNavigationOptions>(options =>
            //{
            //    options.MenuContributors.Add(new AbpArticlesWebMainMenuContributor());
            //});

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpArticlesWebFrontModule>();
            });

            // automapper
            context.Services.AddAutoMapperObjectMapper<AbpArticlesWebFrontModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<ArticlesWebFrontAutoMapperProfile>();
            });

            Configure<RazorPagesOptions>(options =>
            {
                options.Conventions.AddPageRoute("/Writing", "/writing/page/{pageIndex:int}");

                options.Conventions.AddPageRoute("/Writing", "/writing/catalog/{catalogTitle}");
                options.Conventions.AddPageRoute("/Writing", "/writing/catalog/{catalogTitle}/page/{pageIndex:int}");

                options.Conventions.AddPageRoute("/Writing", "/writing/tag/{tagName}");
                options.Conventions.AddPageRoute("/Writing", "/writing/tag/{tagName}/page/{pageIndex:int}");

            });
        }
    }
}
