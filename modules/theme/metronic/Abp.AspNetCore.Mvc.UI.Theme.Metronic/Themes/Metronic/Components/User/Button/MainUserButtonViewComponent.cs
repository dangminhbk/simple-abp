using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.AspNetCore.Mvc.UI.Theme.Metronic.Themes.Metronic.Components.User.Button
{
    public class MainUserButtonViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/Metronic/Components/User/Button/Default.cshtml");
        }
    }
}
