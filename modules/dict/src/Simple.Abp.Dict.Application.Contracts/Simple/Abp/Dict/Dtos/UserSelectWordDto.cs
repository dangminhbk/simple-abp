using System;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Dict.Dtos
{
    [Serializable]
    public class UserSelectWordDto : CreationAuditedEntityDto<Guid>
    {
        public Guid WordId { get; set; }
    }
}