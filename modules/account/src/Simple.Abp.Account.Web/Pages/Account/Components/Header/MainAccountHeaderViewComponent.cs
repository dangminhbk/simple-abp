using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.IdentityServer.Web.Pages.Account.Components.Header
{
    public class MainAccountHeaderViewComponent:AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View($"~/Pages/Account/Components/Header/Default.cshtml");
        }
    }
}
