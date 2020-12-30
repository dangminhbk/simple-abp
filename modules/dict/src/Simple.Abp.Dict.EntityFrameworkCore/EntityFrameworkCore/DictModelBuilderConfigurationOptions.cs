using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Simple.Abp.Dict.EntityFrameworkCore
{
    public class DictModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public DictModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}