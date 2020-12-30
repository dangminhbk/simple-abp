using Simple.Abp.Dict;
using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Simple.Abp.Dict.EntityFrameworkCore
{
    public static class DictDbContextModelCreatingExtensions
    {
        public static void ConfigureDict(
            this ModelBuilder builder,
            Action<DictModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new DictModelBuilderConfigurationOptions(
                DictDbProperties.DbTablePrefix,
                DictDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */


            builder.Entity<Word>(b =>
            {
                b.ToTable(options.TablePrefix + "Words", options.Schema);
                b.ConfigureByConvention();


                /* Configure more properties here */

                b.Property(a => a.Content).HasMaxLength(WordConsts.MaxContentLength);
                b.Property(a => a.NormalizedContent).HasMaxLength(WordConsts.MaxContentLength);

                b.Property(a => a.ES).HasMaxLength(WordConsts.MaxESLength);
                b.Property(a => a.US).HasMaxLength(WordConsts.MaxUSLength);

                b.Property(a => a.ESMp3Url).HasMaxLength(WordConsts.MaxESMp3UrlLength);
                b.Property(a => a.USMp3Url).HasMaxLength(WordConsts.MaxUSMp3UrlLength);
            });


            builder.Entity<UserSelectWord>(b =>
            {
                b.ToTable(options.TablePrefix + "UserSelectWords", options.Schema);
                b.ConfigureByConvention();


                /* Configure more properties here */

                b.Property(a => a.WordId).IsRequired();
            });


            builder.Entity<UserMemoryLog>(b =>
            {
                b.ToTable(options.TablePrefix + "UserMemoryLogs", options.Schema);
                b.ConfigureByConvention();


                /* Configure more properties here */

                b.Property(a => a.WordId).IsRequired();
            });


            builder.Entity<UserCatalogMapping>(b =>
            {
                b.ToTable(options.TablePrefix + "UserCatalogMappings", options.Schema);
                b.ConfigureByConvention();


                /* Configure more properties here */

                b.Property(a => a.CatalogId).IsRequired();
            });


            builder.Entity<UserAssignment>(b =>
            {
                b.ToTable(options.TablePrefix + "UserAssignments", options.Schema);
                b.ConfigureByConvention();


                /* Configure more properties here */

                b.Property(a => a.WordCount).HasDefaultValue(0);
                b.Property(a => a.PhraseCount).HasDefaultValue(0);
                b.Property(a => a.SentenceCount).HasDefaultValue(0);
            });


            builder.Entity<CatalogWordMapping>(b =>
            {
                b.ToTable(options.TablePrefix + "CatalogWordMappings", options.Schema);
                b.ConfigureByConvention();


                /* Configure more properties here */

                b.Property(a => a.CatalogId).IsRequired();
                b.Property(a => a.WordId).IsRequired();

            });


            builder.Entity<Catalog>(b =>
            {
                b.ToTable(options.TablePrefix + "Catalogs", options.Schema);
                b.ConfigureByConvention();


                /* Configure more properties here */

                b.Property(a => a.Title).IsRequired();
            });
        }
    }
}
