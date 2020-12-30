using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Simple.Abp.Dict
{
    [DependsOn(
        typeof(DictApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class DictHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Dict";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(DictApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
