using System;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Dict.Dtos
{
    [Serializable]
    public class CatalogDto : FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }

        public string Desc { get; set; }
    }
}