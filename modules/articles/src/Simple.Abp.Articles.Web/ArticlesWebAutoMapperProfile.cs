using AutoMapper;
using Simple.Abp.Articles.Dtos;
using Simple.Abp.Articles.Web.Pages.Articles.Article.ViewModels;
using Simple.Abp.Articles.Web.Pages.Articles.Catalog.ViewModels;
using Simple.Abp.Articles.Web.Pages.Articles.Tag.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Abp.Articles.Web
{
    public class ArticlesWebAutoMapperProfile:Profile
    {
        public ArticlesWebAutoMapperProfile()
        {
            CreateArticleMappings();
        }

        public void CreateArticleMappings()
        {
            CreateMap<ArticleDto, CreateEditArticleViewModel>();
            CreateMap<CreateEditArticleViewModel, CreateUpdateArticleDto>();

            CreateMap<CreateEditTagViewModel, CreateUpdateTagDto>();
            CreateMap<TagDto, CreateEditTagViewModel>();

            CreateMap<CreateEditCatalogViewModel, CreateUpdateCatalogDto>();
            CreateMap<CatalogDto, CreateEditCatalogViewModel>();
        }
    }

}
