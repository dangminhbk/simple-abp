using System;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Dict.Dtos
{
    [Serializable]
    public class UserCatalogMappingDto : CreationAuditedEntityDto<Guid>
    {
        public Guid CatalogId { get; set; }
    }
}