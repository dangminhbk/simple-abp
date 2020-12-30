namespace Simple.Abp.Dict
{
    public static class DictDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Dict";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Dict";
    }
}
