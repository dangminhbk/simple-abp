using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Simple.Abp.Dict;

namespace Simple.Abp.Dict.EntityFrameworkCore
{
    [ConnectionStringName(DictDbProperties.ConnectionStringName)]
    public class DictDbContext : AbpDbContext<DictDbContext>, IDictDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<Word> Words { get; set; }
        public DbSet<UserSelectWord> UserSelectWords { get; set; }
        public DbSet<UserMemoryLog> UserMemoryLogs { get; set; }
        public DbSet<UserCatalogMapping> UserCatalogMappings { get; set; }
        public DbSet<UserAssignment> UserAssignments { get; set; }
        public DbSet<CatalogWordMapping> CatalogWordMappings { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }

        public DictDbContext(DbContextOptions<DictDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureDict();
        }
    }
}
