using System;

using System.ComponentModel.DataAnnotations;

namespace Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.UserCatalogMapping.ViewModels
{
    public class CreateEditUserCatalogMappingViewModel
    {
        [Display(Name = "UserCatalogMappingCatalogId")]
        public Guid CatalogId { get; set; }
    }
}