using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Simple.Abp.Articles.EntityFrameworkCore
{
    [ConnectionStringName(AbpArticlesDbProperties.ConnectionStringName)]
    public interface IArticlesDbContext : IEfCoreDbContext
    {
        DbSet<Article> Articles { get; set; }

        DbSet<Catalog> Catalogs { get; set; }

        DbSet<Tag> Tags { get; set; }
    }
}
