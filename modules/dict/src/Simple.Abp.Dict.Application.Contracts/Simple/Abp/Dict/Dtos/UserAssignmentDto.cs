using System;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Dict.Dtos
{
    [Serializable]
    public class UserAssignmentDto : FullAuditedEntityDto<Guid>
    {
        public int WordCount { get; set; }

        public int PhraseCount { get; set; }

        public int SentenceCount { get; set; }
    }
}