using System;

using System.ComponentModel.DataAnnotations;

namespace Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.UserAssignment.ViewModels
{
    public class CreateEditUserAssignmentViewModel
    {
        [Display(Name = "UserAssignmentWordCount")]
        public int WordCount { get; set; }

        [Display(Name = "UserAssignmentPhraseCount")]
        public int PhraseCount { get; set; }

        [Display(Name = "UserAssignmentSentenceCount")]
        public int SentenceCount { get; set; }
    }
}