using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Simple.Abp.Dict.MongoDB
{
    [ConnectionStringName(DictDbProperties.ConnectionStringName)]
    public interface IDictMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
