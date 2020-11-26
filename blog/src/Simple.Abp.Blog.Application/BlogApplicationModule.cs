﻿using EasyAbp.Abp.SettingUi;
using Simple.Abp.Articles;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Simple.Abp.Blog
{
    [DependsOn(
        typeof(BlogDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(BlogApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(SettingUiApplicationModule),
        typeof(AbpArticlesApplicationModule)
        )]
    public class BlogApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<BlogApplicationModule>();
            });
        }
    }
}
