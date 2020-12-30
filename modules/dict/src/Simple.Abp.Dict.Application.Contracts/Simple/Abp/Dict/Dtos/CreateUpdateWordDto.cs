using System;
using System.ComponentModel;
namespace Simple.Abp.Dict.Dtos
{
    [Serializable]
    public class CreateUpdateWordDto
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