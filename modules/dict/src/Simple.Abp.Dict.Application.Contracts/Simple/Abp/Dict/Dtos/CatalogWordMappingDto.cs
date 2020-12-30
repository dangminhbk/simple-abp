using System;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Dict.Dtos
{
    [Serializable]
    public class CatalogWordMappingDto : CreationAuditedEntityDto<Guid>
    {
        public Guid CatalogId { get; set; }

        public Guid WordId { get; set; }
    }
}