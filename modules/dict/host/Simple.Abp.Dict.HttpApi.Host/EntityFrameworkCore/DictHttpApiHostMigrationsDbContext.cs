using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Simple.Abp.Dict.EntityFrameworkCore
{
    public class DictHttpApiHostMigrationsDbContext : AbpDbContext<DictHttpApiHostMigrationsDbContext>
    {
        public DictHttpApiHostMigrationsDbContext(DbContextOptions<DictHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureDict();
        }
    }
}
