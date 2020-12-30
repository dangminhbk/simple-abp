using Volo.Abp.Modularity;

namespace Simple.Abp.Dict
{
    [DependsOn(
        typeof(DictApplicationModule),
        typeof(DictDomainTestModule)
        )]
    public class DictApplicationTestModule : AbpModule
    {

    }
}
