using Simple.Abp.Dict;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Simple.Abp.Dict.EntityFrameworkCore
{
    [DependsOn(
        typeof(DictDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class DictEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DictDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<Word, WordRepository>();
                options.AddRepository<UserSelectWord, UserSelectWordRepository>();
                options.AddRepository<UserMemoryLog, UserMemoryLogRepository>();
                options.AddRepository<UserCatalogMapping, UserCatalogMappingRepository>();
                options.AddRepository<UserAssignment, UserAssignmentRepository>();
                options.AddRepository<CatalogWordMapping, CatalogWordMappingRepository>();
                options.AddRepository<Catalog, CatalogRepository>();
            });
        }
    }
}
