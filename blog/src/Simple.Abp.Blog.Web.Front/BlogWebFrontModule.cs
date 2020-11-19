using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Simple.Abp.Articles.Web.Front;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Simple.Abp.Blog.Web.Front
{

    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpArticlesWebFrontModule),
        typeof(BlogHttpApiModule),
        typeof(BlogHttpApiClientModule)
    )]
    public class BlogWebFrontModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            context.Services.AddAutoMapperObjectMapper<BlogWebFrontModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                //options.AddProfile<KAWebAutoMapperProfile>();
            });

            context.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            app.UseVirtualFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAuditing();
            app.UseConfiguredEndpoints(options => {
                options.MapRazorPages();
            });
        }

    }
}
