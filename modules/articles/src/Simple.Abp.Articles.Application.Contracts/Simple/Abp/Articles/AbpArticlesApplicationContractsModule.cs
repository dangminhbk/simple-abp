using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Simple.Abp.Articles
{
    [DependsOn(
        typeof(AbpDddApplicationModule),
        typeof(AbpArticlesDomainSharedModule)    
    )]
    public class AbpArticlesApplicationContractsModule:AbpModule
    {
    }
}
