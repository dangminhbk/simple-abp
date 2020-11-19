using Abp.AspNetCore.Mvc.UI.Theme.Metronic;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Simple.Abp.Account.Web;
using Simple.Abp.Blog.EntityFrameworkCore;
using Simple.Abp.Blog.IdentityServer.Menus;
using Simple.Abp.Blog.Localization;
using System.IO;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;

namespace Simple.Abp.Blog
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(SimpleAbpAccountWebIdentityServerModule),
        typeof(AbpAccountWebIdentityServerModule),
        typeof(AbpAccountApplicationModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpAspNetCoreMvcUiMetronicThemeModule),
        typeof(BlogEntityFrameworkCoreDbMigrationsModule)
        )]
    public class BlogIdentityServerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<BlogResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );

                //options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
                //options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                //options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
                //options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
                //options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
                //options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
                //options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
                //options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            });

            Configure<AbpAuditingOptions>(options =>
            {
                //options.IsEnabledForGetRequests = true;
                options.ApplicationName = "AuthServer";
            });

            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<BlogDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Simple.Abp.Blog.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<BlogDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Simple.Abp.Blog.Domain"));

                    options.FileSets.ReplaceEmbeddedByPhysical<BlogIdentityServerModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}Abp.AspNetCore.Mvc.UI.Theme.Metronic"));
                });
            }

            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            });

            Configure<MetronicOptions>(options =>
            {
                options.StandardMenu = StandardMenus.User;
            });

            ConfigureNavigationServices(configuration);

        }

        private void ConfigureNavigationServices(IConfiguration configuration)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new BlogMenuContributor(configuration));
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAbpRequestLocalization();

            if (!env.IsDevelopment())
            {
                app.UseErrorPage();
            }

            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseAuthentication();

            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseAuditing();
            app.UseConfiguredEndpoints();
        }
    }
}
