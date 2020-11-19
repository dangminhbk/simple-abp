using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Simple.Abp.Articles.EntityFrameworkCore
{
    public static class ArticlesDbContextModelBuilderExtensions
    {
        public static void ConfigureArticles(
            [NotNull] this ModelBuilder builder,
            [CanBeNull] Action<ArticlesModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new ArticlesModelBuilderConfigurationOptions(
                AbpArticlesDbProperties.DbTablePrefix,
                AbpArticlesDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            // article
            builder.Entity<Article>(b =>
            {
                b.ToTable(options.TablePrefix + "Articles", options.Schema);

                b.ConfigureByConvention();

                b.Property(a => a.CatalogId).IsRequired();

                b.Property(a => a.SEOPath)
                      .HasMaxLength(ArticleConsts.MaxSEOPathLength);

                b.Property(a => a.Title).IsRequired()
                    .HasMaxLength(ArticleConsts.MaxTitleLength);

                b.Property(a => a.Content).IsRequired();

                b.Property(a => a.IsRefinement).HasDefaultValue(false);
                b.Property(a => a.IsTop).HasDefaultValue(false);
                b.Property(a => a.Order).HasDefaultValue(0);
                b.Property(a => a.State).HasDefaultValue(EnumArticleState.Default);
                b.Property(a => a.Summary).HasMaxLength(ArticleConsts.MaxSummaryLength);
                b.Property(a => a.Tag).HasMaxLength(TagConsts.MaxNameLength);
            });

            // catalog
            builder.Entity<Catalog>(b =>
            {
                b.ToTable(options.TablePrefix + "Catalogs", options.Schema);

                b.ConfigureByConvention();

                b.Property(a => a.Title).IsRequired()
                    .HasMaxLength(CatalogConsts.MaxTitleLength);

                b.Property(a => a.Description)
                   .HasMaxLength(CatalogConsts.MaxDescriptionLength);
            });

            // tag
            builder.Entity<Tag>(b =>
            {
                b.ToTable(options.TablePrefix + "Tags", options.Schema);

                b.ConfigureByConvention();

                b.Property(a => a.Name).IsRequired()
                    .HasMaxLength(TagConsts.MaxNameLength);
            });
        }
    }
}
