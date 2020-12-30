using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Simple.Abp.Dict
{
    [DependsOn(
        typeof(DictHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class DictConsoleApiClientModule : AbpModule
    {
        
    }
}
