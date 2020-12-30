using System;
using System.ComponentModel;
namespace Simple.Abp.Dict.Dtos
{
    [Serializable]
    public class CreateUpdateCatalogWordMappingDto
    {
        public Guid CatalogId { get; set; }

        public Guid WordId { get; set; }
    }
}