using System;
using System.ComponentModel;
namespace Simple.Abp.Dict.Dtos
{
    [Serializable]
    public class CreateUpdateCatalogDto
    {
        public string Title { get; set; }

        public string Desc { get; set; }
    }
}