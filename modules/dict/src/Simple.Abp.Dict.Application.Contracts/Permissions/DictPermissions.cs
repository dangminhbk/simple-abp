using Volo.Abp.Reflection;

namespace Simple.Abp.Dict.Permissions
{
    public class DictPermissions
    {
        public const string GroupName = "Dict";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(DictPermissions));
        }

        public class Word
        {
            public const string Default = GroupName + ".Word";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class UserSelectWord
        {
            public const string Default = GroupName + ".UserSelectWord";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class UserMemoryLog
        {
            public const string Default = GroupName + ".UserMemoryLog";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class UserCatalogMapping
        {
            public const string Default = GroupName + ".UserCatalogMapping";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class UserAssignment
        {
            public const string Default = GroupName + ".UserAssignment";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class CatalogWordMapping
        {
            public const string Default = GroupName + ".CatalogWordMapping";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Catalog
        {
            public const string Default = GroupName + ".Catalog";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
