using AutoMapper;
using Simple.Abp.Articles.Dtos;

namespace Simple.Abp.Articles
{
    public class ArticlesApplicationAutoMapperProfile : Profile
    {
        public ArticlesApplicationAutoMapperProfile()
        {
            CreateMap<Article, ArticleDto>();
            CreateMap<CreateUpdateArticleDto, Article>(MemberList.Source);

            CreateMap<Catalog, CatalogDto>();
            CreateMap<CreateUpdateCatalogDto, Catalog>(MemberList.Source);

            CreateMap<Tag,TagDto>();
            CreateMap<CreateUpdateTagDto, Tag>(MemberList.Source);
        }
    }
}
