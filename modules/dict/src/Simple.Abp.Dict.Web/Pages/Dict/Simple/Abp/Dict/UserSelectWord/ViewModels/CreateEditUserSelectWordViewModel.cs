using System;

using System.ComponentModel.DataAnnotations;

namespace Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.UserSelectWord.ViewModels
{
    public class CreateEditUserSelectWordViewModel
    {
        [Display(Name = "UserSelectWordWordId")]
        public Guid WordId { get; set; }
    }
}