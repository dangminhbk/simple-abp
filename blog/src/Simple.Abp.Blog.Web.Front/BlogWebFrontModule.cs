using Abp.AspNetCore.Mvc.UI.Theme.Cactus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Simple.Abp.Articles.Web.Front;
using Simple.Abp.Blog.Web.Menus;
using System;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.OpenIdConnect;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client.IdentityModel.Web;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.UI.Navigation.Urls;

namespace Simple.Abp.Blog.Web.Front
{

    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpAspNetCoreAuthenticationOpenIdConnectModule),
        typeof(AbpHttpClientIdentityModelWebModule),
        typeof(AbpArticlesWebFrontModule),
        typeof(AbpAspNetCoreMvcUiCactusThemeModule),
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

            ConfigureUrls(configuration);
            ConfigureAuthentication(context,configuration);
            ConfigureNavigationServices(configuration);
            ConfigureRazorPages();
            Configure<CactusOptions>(options =>
            {
                options.WebsiteFiling = "鲁ICP备19044904号-1";
                options.WebsiteFilingUrl = "http://beian.miit.gov.cn";
                options.WebInfo = "Copyright &copy; 2019-2020";
                options.CdnHost = "https://ka-1252696628.cos.ap-beijing.myqcloud.com";
            });

            context.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
        }
        private void ConfigureUrls(IConfiguration configuration)
        {
            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies", options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(365);
            })
            .AddAbpOpenIdConnect("oidc", options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                options.ResponseType = OpenIdConnectResponseType.CodeIdToken;

                options.ClientId = configuration["AuthServer:ClientId"];
                options.ClientSecret = configuration["AuthServer:ClientSecret"];

                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;

                options.Scope.Add("role");
                options.Scope.Add("email");
                options.Scope.Add("phone");
                options.Scope.Add("Blog");
            });
        }

        private void ConfigureNavigationServices(IConfiguration configuration)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new BlogMenuContributor(configuration));
            });
        }

        private void ConfigureRazorPages()
        {
            Configure<RazorPagesOptions>(options =>
            {
                options.Conventions.AddPageRoute("/bilibili", "/bilibili/page/{pageIndex:int}");
                options.Conventions.AddPageRoute("/projects", "/projects/page/{pageIndex:int}");
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            ConfigureEndpointHttps(app);

            app.UseVirtualFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAuditing();
            app.UseConfiguredEndpoints(options => {
                options.MapRazorPages();
            });
        }

        private void ConfigureEndpointHttps(IApplicationBuilder app)
        {
            var forwardOptions = new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
                RequireHeaderSymmetry = false
            };

            forwardOptions.KnownNetworks.Clear();
            forwardOptions.KnownProxies.Clear();

            // ref: https://github.com/aspnet/Docs/issues/2384
            app.UseForwardedHeaders(forwardOptions);
        }

    }
}
