using Simple.Abp.Dict.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Simple.Abp.Dict.Permissions
{
    public class DictPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(DictPermissions.GroupName, L("Permission:Dict"));

            var wordPermission = myGroup.AddPermission(DictPermissions.Word.Default, L("Permission:Word"));
            wordPermission.AddChild(DictPermissions.Word.Create, L("Permission:Create"));
            wordPermission.AddChild(DictPermissions.Word.Update, L("Permission:Update"));
            wordPermission.AddChild(DictPermissions.Word.Delete, L("Permission:Delete"));

            var userSelectWordPermission = myGroup.AddPermission(DictPermissions.UserSelectWord.Default, L("Permission:UserSelectWord"));
            userSelectWordPermission.AddChild(DictPermissions.UserSelectWord.Create, L("Permission:Create"));
            userSelectWordPermission.AddChild(DictPermissions.UserSelectWord.Update, L("Permission:Update"));
            userSelectWordPermission.AddChild(DictPermissions.UserSelectWord.Delete, L("Permission:Delete"));

            var userMemoryLogPermission = myGroup.AddPermission(DictPermissions.UserMemoryLog.Default, L("Permission:UserMemoryLog"));
            userMemoryLogPermission.AddChild(DictPermissions.UserMemoryLog.Create, L("Permission:Create"));
            userMemoryLogPermission.AddChild(DictPermissions.UserMemoryLog.Update, L("Permission:Update"));
            userMemoryLogPermission.AddChild(DictPermissions.UserMemoryLog.Delete, L("Permission:Delete"));

            var userCatalogMappingPermission = myGroup.AddPermission(DictPermissions.UserCatalogMapping.Default, L("Permission:UserCatalogMapping"));
            userCatalogMappingPermission.AddChild(DictPermissions.UserCatalogMapping.Create, L("Permission:Create"));
            userCatalogMappingPermission.AddChild(DictPermissions.UserCatalogMapping.Update, L("Permission:Update"));
            userCatalogMappingPermission.AddChild(DictPermissions.UserCatalogMapping.Delete, L("Permission:Delete"));

            var userAssignmentPermission = myGroup.AddPermission(DictPermissions.UserAssignment.Default, L("Permission:UserAssignment"));
            userAssignmentPermission.AddChild(DictPermissions.UserAssignment.Create, L("Permission:Create"));
            userAssignmentPermission.AddChild(DictPermissions.UserAssignment.Update, L("Permission:Update"));
            userAssignmentPermission.AddChild(DictPermissions.UserAssignment.Delete, L("Permission:Delete"));

            var catalogWordMappingPermission = myGroup.AddPermission(DictPermissions.CatalogWordMapping.Default, L("Permission:CatalogWordMapping"));
            catalogWordMappingPermission.AddChild(DictPermissions.CatalogWordMapping.Create, L("Permission:Create"));
            catalogWordMappingPermission.AddChild(DictPermissions.CatalogWordMapping.Update, L("Permission:Update"));
            catalogWordMappingPermission.AddChild(DictPermissions.CatalogWordMapping.Delete, L("Permission:Delete"));

            var catalogPermission = myGroup.AddPermission(DictPermissions.Catalog.Default, L("Permission:Catalog"));
            catalogPermission.AddChild(DictPermissions.Catalog.Create, L("Permission:Create"));
            catalogPermission.AddChild(DictPermissions.Catalog.Update, L("Permission:Update"));
            catalogPermission.AddChild(DictPermissions.Catalog.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DictResource>(name);
        }
    }
}
