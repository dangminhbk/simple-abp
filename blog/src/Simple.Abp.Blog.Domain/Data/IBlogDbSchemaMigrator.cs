using System.Threading.Tasks;

namespace Simple.Abp.Blog.Data
{
    public interface IBlogDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
