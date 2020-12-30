using System;
using System.ComponentModel;
namespace Simple.Abp.Dict.Dtos
{
    [Serializable]
    public class CreateUpdateUserSelectWordDto
    {
        public Guid WordId { get; set; }
    }
}