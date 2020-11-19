using Simple.Abp.Blog.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Simple.Abp.Blog
{
    [DependsOn(
        typeof(BlogEntityFrameworkCoreTestModule)
        )]
    public class BlogDomainTestModule : AbpModule
    {

    }
}