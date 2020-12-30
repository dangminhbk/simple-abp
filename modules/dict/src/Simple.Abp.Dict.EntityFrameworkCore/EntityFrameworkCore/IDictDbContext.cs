using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Simple.Abp.Dict;

namespace Simple.Abp.Dict.EntityFrameworkCore
{
    [ConnectionStringName(DictDbProperties.ConnectionStringName)]
    public interface IDictDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<Word> Words { get; set; }
        DbSet<UserSelectWord> UserSelectWords { get; set; }
        DbSet<UserMemoryLog> UserMemoryLogs { get; set; }
        DbSet<UserCatalogMapping> UserCatalogMappings { get; set; }
        DbSet<UserAssignment> UserAssignments { get; set; }
        DbSet<CatalogWordMapping> CatalogWordMappings { get; set; }
        DbSet<Catalog> Catalogs { get; set; }
    }
}
