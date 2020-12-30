using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Simple.Abp.Dict
{
    [DependsOn(
        typeof(DictDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class DictApplicationContractsModule : AbpModule
    {

    }
}
