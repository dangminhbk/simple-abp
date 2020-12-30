using Simple.Abp.Dict;
using Simple.Abp.Dict.Dtos;
using AutoMapper;

namespace Simple.Abp.Dict
{
    public class DictApplicationAutoMapperProfile : Profile
    {
        public DictApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Word, WordDto>();
            CreateMap<CreateUpdateWordDto, Word>(MemberList.Source);
            CreateMap<UserSelectWord, UserSelectWordDto>();
            CreateMap<CreateUpdateUserSelectWordDto, UserSelectWord>(MemberList.Source);
            CreateMap<UserMemoryLog, UserMemoryLogDto>();
            CreateMap<CreateUpdateUserMemoryLogDto, UserMemoryLog>(MemberList.Source);
            CreateMap<UserCatalogMapping, UserCatalogMappingDto>();
            CreateMap<CreateUpdateUserCatalogMappingDto, UserCatalogMapping>(MemberList.Source);
            CreateMap<UserAssignment, UserAssignmentDto>();
            CreateMap<CreateUpdateUserAssignmentDto, UserAssignment>(MemberList.Source);
            CreateMap<CatalogWordMapping, CatalogWordMappingDto>();
            CreateMap<CreateUpdateCatalogWordMappingDto, CatalogWordMapping>(MemberList.Source);
            CreateMap<Catalog, CatalogDto>();
            CreateMap<CreateUpdateCatalogDto, Catalog>(MemberList.Source);
        }
    }
}
