using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Articles.Web.Front.Shared.Components.Article
{
    public class ArticleViewComponent: AbpViewComponent
    {
        public IViewComponentResult Invoke(List<ArticleDto> modelList)
        {
            return View("~/Shared/Components/Article/Default.cshtml", modelList);
        }
    }
}
