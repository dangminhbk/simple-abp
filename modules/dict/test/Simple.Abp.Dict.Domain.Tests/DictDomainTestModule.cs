using Simple.Abp.Dict.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Simple.Abp.Dict
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(DictEntityFrameworkCoreTestModule)
        )]
    public class DictDomainTestModule : AbpModule
    {
        
    }
}
