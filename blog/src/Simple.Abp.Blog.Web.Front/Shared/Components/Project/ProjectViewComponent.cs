using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Dtos;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Blog.Web.Front.Shared.Components.Project
{
    public class ProjectViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke(List<ArticleDto> modelList)
        {
            return View("~/Shared/Components/Project/Default.cshtml", modelList);
        }
    }
}
