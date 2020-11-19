using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Simple.Abp.Articles.EntityFrameworkCore
{
    [DependsOn(
      typeof(AbpArticlesDomainModule),
      typeof(AbpEntityFrameworkCoreModule)
    )]
    public class AbpArticlesEntityFrameworkCoreModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ArticlesDbContext>(options =>
            {
                options.AddRepository<Article, EfCoreArticleRepository>();
                options.AddRepository<Catalog, EfCoreCatalogRepository>();
                options.AddRepository<Tag, EfCoreTagRepository>();
            });
        }
    }
}
