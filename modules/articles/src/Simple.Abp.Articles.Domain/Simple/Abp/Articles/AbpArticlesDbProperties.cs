using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;

namespace Simple.Abp.Articles
{
    public class AbpArticlesDbProperties
    {
        public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

        public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

        public const string ConnectionStringName = "AbpArticle";
    }
}
