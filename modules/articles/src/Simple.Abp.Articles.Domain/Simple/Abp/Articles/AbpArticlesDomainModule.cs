using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Simple.Abp.Articles
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(AbpArticlesDomainSharedModule)
    )]
    public class AbpArticlesDomainModule:AbpModule
    {
    }
}
