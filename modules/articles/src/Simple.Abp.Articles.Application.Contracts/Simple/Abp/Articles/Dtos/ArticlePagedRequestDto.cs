using System.ComponentModel.DataAnnotations;

namespace Simple.Abp.Articles.Dtos
{
    public class ArticlePagedRequestDto: SimpleAbpPagedRequest
    {
        [StringLength(CatalogConsts.MaxTitleLength)]
        public string CatalogTitle { get; set; }

        [StringLength(TagConsts.MaxNameLength)]
        public string TagName { get; set; }
    }
}
