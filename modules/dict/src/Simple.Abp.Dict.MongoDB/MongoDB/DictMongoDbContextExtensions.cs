using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Simple.Abp.Dict.MongoDB
{
    public static class DictMongoDbContextExtensions
    {
        public static void ConfigureDict(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new DictMongoModelBuilderConfigurationOptions(
                DictDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}