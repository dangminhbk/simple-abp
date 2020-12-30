using System;

using System.ComponentModel.DataAnnotations;

namespace Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.Word.ViewModels
{
    public class CreateEditWordViewModel
    {
        [Display(Name = "WordContent")]
        public string Content { get; set; }

        [Display(Name = "WordNormalizedContent")]
        public string NormalizedContent { get; set; }

        [Display(Name = "WordES")]
        public string ES { get; set; }

        [Display(Name = "WordUS")]
        public string US { get; set; }

        [Display(Name = "WordESMp3Url")]
        public string ESMp3Url { get; set; }

        [Display(Name = "WordUSMp3Url")]
        public string USMp3Url { get; set; }

        [Display(Name = "WordType")]
        public EnumWordType Type { get; set; }
    }
}