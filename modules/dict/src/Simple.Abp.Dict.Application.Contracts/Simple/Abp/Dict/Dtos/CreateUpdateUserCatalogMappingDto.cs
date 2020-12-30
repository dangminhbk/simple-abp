using System;
using System.ComponentModel;
namespace Simple.Abp.Dict.Dtos
{
    [Serializable]
    public class CreateUpdateUserCatalogMappingDto
    {
        public Guid CatalogId { get; set; }
    }
}