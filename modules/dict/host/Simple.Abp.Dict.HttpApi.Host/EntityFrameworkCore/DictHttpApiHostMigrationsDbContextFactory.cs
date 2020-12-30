using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Simple.Abp.Dict.EntityFrameworkCore
{
    public class DictHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<DictHttpApiHostMigrationsDbContext>
    {
        public DictHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<DictHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Dict"));

            return new DictHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
