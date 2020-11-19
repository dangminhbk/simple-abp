using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Web.Front.Shared.Components.Pagination;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Articles.Web.Front.Shared.Components.Pagination
{
    public class PaginationViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke(PaginationViewModel vm)
        {
            return View("~/Shared/Components/Pagination/Default.cshtml", vm);
        }
    }
}
