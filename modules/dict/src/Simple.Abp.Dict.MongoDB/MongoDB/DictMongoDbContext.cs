using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Simple.Abp.Dict.MongoDB
{
    [ConnectionStringName(DictDbProperties.ConnectionStringName)]
    public class DictMongoDbContext : AbpMongoDbContext, IDictMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureDict();
        }
    }
}