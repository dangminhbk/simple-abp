namespace Simple.Abp.Articles.Permissions
{
    public static class ArticlesPermissions
    {
        public const string GroupName = "Articles";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class Article
        {
            public const string Default = GroupName + ".Article";
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

        public class Tag
        {
            public const string Default = GroupName + ".Tag";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
