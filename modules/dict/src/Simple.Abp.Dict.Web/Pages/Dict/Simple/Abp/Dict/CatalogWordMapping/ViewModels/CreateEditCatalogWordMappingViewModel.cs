using System;

using System.ComponentModel.DataAnnotations;

namespace Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.CatalogWordMapping.ViewModels
{
    public class CreateEditCatalogWordMappingViewModel
    {
        [Display(Name = "CatalogWordMappingCatalogId")]
        public Guid CatalogId { get; set; }

        [Display(Name = "CatalogWordMappingWordId")]
        public Guid WordId { get; set; }
    }
}