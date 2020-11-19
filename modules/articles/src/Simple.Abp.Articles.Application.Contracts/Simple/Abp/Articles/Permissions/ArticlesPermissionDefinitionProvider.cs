using Simple.Abp.Articles.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Simple.Abp.Articles.Permissions
{
    public class ArticlesPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ArticlesPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(KAPermissions.MyPermission1, L("Permission:MyPermission1"));

            var articlePermission = myGroup.AddPermission(ArticlesPermissions.Article.Default, L("Permission:Article"));
            articlePermission.AddChild(ArticlesPermissions.Article.Create, L("Permission:Create"));
            articlePermission.AddChild(ArticlesPermissions.Article.Update, L("Permission:Update"));
            articlePermission.AddChild(ArticlesPermissions.Article.Delete, L("Permission:Delete"));

            var articleCatalogPermission = myGroup.AddPermission(ArticlesPermissions.Catalog.Default, L("Permission:Catalog"));
            articleCatalogPermission.AddChild(ArticlesPermissions.Catalog.Create, L("Permission:Create"));
            articleCatalogPermission.AddChild(ArticlesPermissions.Catalog.Update, L("Permission:Update"));
            articleCatalogPermission.AddChild(ArticlesPermissions.Catalog.Delete, L("Permission:Delete"));

            var articleTagPermission = myGroup.AddPermission(ArticlesPermissions.Tag.Default, L("Permission:Tag"));
            articleTagPermission.AddChild(ArticlesPermissions.Tag.Create, L("Permission:Create"));
            articleTagPermission.AddChild(ArticlesPermissions.Tag.Update, L("Permission:Update"));
            articleTagPermission.AddChild(ArticlesPermissions.Tag.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            //return name;
            return LocalizableString.Create<ArticlesResource>(name);
        }
    }
}
