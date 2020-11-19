using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.AspNetCore.Mvc.UI.Theme.Metronic.Themes.Metronic.Components.BreadCrumb
{
    public class MainSubHeaderBreadCrumbViewComponent: AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/Metronic/Components/BreadCrumb/Default.cshtml");
        }
    }
}
