using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Localization;

namespace Abp.AspNetCore.Mvc.UI.Theme.Metronic.Themes.Metronic.Components.LanguageSwitch
{
    public class LanguageSwitchViewComponentModel
    {
        public LanguageInfo CurrentLanguage { get; set; }

        public List<LanguageInfo> OtherLanguages { get; set; }

        public string GetLogoUrl(string name)
        {
            switch (name)
            {
                case "en":
                    return "/themes/img/language/260-united-kingdom.svg";
                case "zh-Hans":
                    return "/themes/img/language/015-china.svg";
                default:
                    return "";
            }
        }
    }
}
