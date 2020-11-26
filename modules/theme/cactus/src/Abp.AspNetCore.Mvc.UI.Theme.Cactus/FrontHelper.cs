using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Abp.AspNetCore.Mvc.UI.Theme.Cactus
{
    public class FrontHelper: IScopedDependency
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FrontHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsThemeNight()
        {
            string theme = string.Empty;
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("theme", out theme);
            return theme == "night";
        }


        public string GetStyleCss()
        {
            string light = IsThemeNight() ? "" : "-light";
            return $"/libs/blog/css/style{light}.css";
        }

        public string GetRtlCss()
        {
            string light = IsThemeNight() ? "" : "-light";
            return $"/libs/blog/css/rtl{light}.css";
        }

    }
}
