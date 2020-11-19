using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Simple.Abp.Articles.EntityFrameworkCore
{
    [ConnectionStringName(AbpArticlesDbProperties.ConnectionStringName)]
    public class ArticlesDbContext : AbpDbContext<ArticlesDbContext>, IArticlesDbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public ArticlesDbContext(DbContextOptions<ArticlesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureArticles();
        }
    }
}
