using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;

namespace Abp.AspNetCore.Mvc.UI.Theme.Cactus
{
    [ThemeName(Name)]
    public class CactusTheme : ITransientDependency, ITheme
    {
        public const string Name = "Cactus";
        public string GetLayout(string name, bool fallbackToDefault = true)
        {
            switch (name)
            {
                case StandardLayouts.Application:
                    return "~/Themes/Cactus/Layouts/Application.cshtml";
                case "Application2":
                    return "~/Themes/Cactus/Layouts/Application2.cshtml";
                default:
                    return fallbackToDefault ? "~/Themes/Cactus/Layouts/Application.cshtml" : null;
            }
        }
    }
}
