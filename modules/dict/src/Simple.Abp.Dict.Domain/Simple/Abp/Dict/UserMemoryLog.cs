using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Simple.Abp.Dict
{
    public class UserMemoryLog : CreationAuditedEntity<Guid>
    {
        public Guid WordId { get; set; }

        public EnumUserMemoryLogType Type { get; set; }

        protected UserMemoryLog()
        {
        }

        public UserMemoryLog(
            Guid id, 
            Guid wordId, 
            EnumUserMemoryLogType type
        ) : base(id)
        {
            WordId = wordId;
            Type = type;
        }
    }
}
