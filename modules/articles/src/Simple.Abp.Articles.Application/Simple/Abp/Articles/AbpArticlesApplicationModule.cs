using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Simple.Abp.Articles
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpArticlesDomainModule),
        typeof(AbpArticlesApplicationContractsModule)
    )] 
    public class AbpArticlesApplicationModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpArticlesApplicationModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<ArticlesApplicationAutoMapperProfile>();
            });
        }
    }
}
