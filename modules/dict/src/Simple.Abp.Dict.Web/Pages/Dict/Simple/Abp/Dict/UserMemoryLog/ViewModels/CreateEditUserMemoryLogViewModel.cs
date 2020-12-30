using System;

using System.ComponentModel.DataAnnotations;

namespace Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.UserMemoryLog.ViewModels
{
    public class CreateEditUserMemoryLogViewModel
    {
        [Display(Name = "UserMemoryLogWordId")]
        public Guid WordId { get; set; }

        [Display(Name = "UserMemoryLogType")]
        public EnumUserMemoryLogType Type { get; set; }
    }
}