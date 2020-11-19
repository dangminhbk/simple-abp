using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Simple.Abp.Articles.Dtos
{
    [Serializable]
    public class CreateUpdateCatalogDto
    {
        public virtual Guid? ParentId { get; set; }

        [Required]
        [StringLength(CatalogConsts.MaxTitleLength)]
        public virtual string Title { get; set; }

        [StringLength(CatalogConsts.MaxDescriptionLength)]
        public virtual string Description { get; set; }
    }
}