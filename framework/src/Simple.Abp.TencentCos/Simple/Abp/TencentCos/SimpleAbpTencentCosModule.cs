using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Myvas.AspNetCore.TencentCos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace Simple.Abp.TencentCos
{
    public class SimpleAbpTencentCosModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var section = configuration.GetSection("TencentCos");
            var tencentCosOptions = section.Get<SimpleAbpTencentCosOption>();

            if (tencentCosOptions != null)
            {
                Configure<SimpleAbpTencentCosOption>(section);
                Configure<TencentCosOptions>(section);
            }

            context.Services.AddTencentCos(options => { });
        }
    }
}
