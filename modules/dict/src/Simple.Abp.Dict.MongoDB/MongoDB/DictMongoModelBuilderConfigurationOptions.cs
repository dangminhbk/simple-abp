using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Simple.Abp.Dict.MongoDB
{
    public class DictMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public DictMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}