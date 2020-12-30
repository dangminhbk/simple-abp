using System;

using System.ComponentModel.DataAnnotations;

namespace Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.Catalog.ViewModels
{
    public class CreateEditCatalogViewModel
    {
        [Display(Name = "CatalogTitle")]
        public string Title { get; set; }

        [Display(Name = "CatalogDesc")]
        public string Desc { get; set; }
    }
}