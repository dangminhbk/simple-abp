using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Simple.Abp.Articles.Web.Front
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
    }
}
