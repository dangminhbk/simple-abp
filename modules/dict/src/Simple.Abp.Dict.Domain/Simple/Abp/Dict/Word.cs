using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Simple.Abp.Dict
{
    public class Word:FullAuditedEntity<Guid>
    {
        public string Content { get; set; }

        public string NormalizedContent { get; set; }

        public string ES { get; set; }

        public string US { get; set; }

        public string ESMp3Url { get; set; }

        public string USMp3Url { get; set; }

        public EnumWordType Type { get; set; }

        protected Word()
        {
        }

        public Word(
            Guid id, 
            string content, 
            string normalizedContent, 
            string eS, 
            string uS, 
            string eSMp3Url, 
            string uSMp3Url, 
            EnumWordType type
        ) : base(id)
        {
            Content = content;
            NormalizedContent = normalizedContent;
            ES = eS;
            US = uS;
            ESMp3Url = eSMp3Url;
            USMp3Url = uSMp3Url;
            Type = type;
        }
    }
}
