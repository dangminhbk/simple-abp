using Simple.Abp.Articles.Localization;
using Simple.Abp.Articles.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Simple.Abp.Articles.Web.Navigation
{
    public class AbpArticlesMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            await ConfigureArticlesMenuAsync(context);
        }

        private async Task ConfigureArticlesMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<ArticlesResource>();

            var administrationMenu = context.Menu.GetAdministration();

            var articleMenu = new ApplicationMenuItem(ArticlesMenus.GroupName, 
                l["Menu:ArticlesManager"], icon: "fas fa-book-open");
            administrationMenu.AddItem(articleMenu);


            if (await context.IsGrantedAsync(ArticlesPermissions.Article.Default))
            {
                articleMenu.AddItem(
                    new ApplicationMenuItem(ArticlesMenus.Article, l["Menu:Article"], "/Articles/Article")
                );
            }
            if (await context.IsGrantedAsync(ArticlesPermissions.Catalog.Default))
            {
                articleMenu.AddItem(
                    new ApplicationMenuItem(ArticlesMenus.Catalog, l["Menu:Catalog"], "/Articles/Catalog")
                );
            }
            if (await context.IsGrantedAsync(ArticlesPermissions.Tag.Default))
            {
                articleMenu.AddItem(
                    new ApplicationMenuItem(ArticlesMenus.Tag, l["Menu:Tag"], "/Articles/Tag")
                );
            }
        }
    }
}
