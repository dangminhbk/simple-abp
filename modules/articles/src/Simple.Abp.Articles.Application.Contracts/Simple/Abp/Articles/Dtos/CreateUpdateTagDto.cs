using System;
using System.ComponentModel.DataAnnotations;

namespace Simple.Abp.Articles.Dtos
{
    [Serializable]
    public class CreateUpdateTagDto
    {
        [Required]
        [StringLength(TagConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}