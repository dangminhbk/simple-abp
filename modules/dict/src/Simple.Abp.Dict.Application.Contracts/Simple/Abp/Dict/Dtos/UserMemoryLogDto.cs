using System;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Dict.Dtos
{
    [Serializable]
    public class UserMemoryLogDto : CreationAuditedEntityDto<Guid>
    {
        public Guid WordId { get; set; }

        public EnumUserMemoryLogType Type { get; set; }
    }
}