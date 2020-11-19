using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Abp.Articles.Web.Front
{
    public class ArticlesWebFrontAutoMapperProfile:Profile
    {
        public ArticlesWebFrontAutoMapperProfile()
        {
            //CreateArticleMappings();
        }

        public void CreateArticleMappings()
        {
            //CreateMap<ArticleDto, CreateEditArticleViewModel>();
            //CreateMap<CreateEditArticleViewModel, CreateUpdateArticleDto>();

            //CreateMap<CreateEditTagViewModel, CreateUpdateTagDto>();
            //CreateMap<TagDto, CreateEditTagViewModel>();

            //CreateMap<CreateEditCatalogViewModel, CreateUpdateCatalogDto>();
            //CreateMap<CatalogDto, CreateEditCatalogViewModel>();
        }
    }
}
