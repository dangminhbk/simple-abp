using System;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Dict.Dtos
{
    [Serializable]
    public class WordDto : FullAuditedEntityDto<Guid>
    {
        public string Content { get; set; }

        public string NormalizedContent { get; set; }

        public string ES { get; set; }

        public string US { get; set; }

        public string ESMp3Url { get; set; }

        public string USMp3Url { get; set; }

        public EnumWordType Type { get; set; }
    }
}