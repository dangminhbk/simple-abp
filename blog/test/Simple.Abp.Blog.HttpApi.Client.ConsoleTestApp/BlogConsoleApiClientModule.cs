using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Simple.Abp.Blog.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(BlogHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class BlogConsoleApiClientModule : AbpModule
    {
        
    }
}
