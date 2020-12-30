using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Simple.Abp.Dict
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(DictDomainSharedModule)
    )]
    public class DictDomainModule : AbpModule
    {

    }
}
