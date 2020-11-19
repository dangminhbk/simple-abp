using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;

namespace Abp.AspNetCore.Mvc.UI.Theme.Metronic
{
    [ThemeName(Name)]
    public class MetronicTheme : ITransientDependency, ITheme
    {
        public const string Name = "Metronic";
        public string GetLayout(string name, bool fallbackToDefault = true)
        {
            switch (name)
            {
                case StandardLayouts.Application:
                    return "~/Themes/Metronic/Layouts/Application.cshtml";
                case StandardLayouts.Account:
                    return "~/Themes/Metronic/Layouts/Account.cshtml";
                case StandardLayouts.Empty:
                    return "~/Themes/Metronic/Layouts/Empty.cshtml";
                default:
                    return fallbackToDefault ? "~/Themes/Metronic/Layouts/Application.cshtml" : null;
            }
        }
    }
}
