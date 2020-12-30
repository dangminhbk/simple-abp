using System;
using System.ComponentModel;
namespace Simple.Abp.Dict.Dtos
{
    [Serializable]
    public class CreateUpdateUserMemoryLogDto
    {
        public Guid WordId { get; set; }

        public EnumUserMemoryLogType Type { get; set; }
    }
}