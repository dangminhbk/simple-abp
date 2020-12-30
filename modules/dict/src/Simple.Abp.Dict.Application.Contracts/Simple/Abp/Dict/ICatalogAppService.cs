using System;
using Simple.Abp.Dict.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Dict
{
    public interface ICatalogAppService :
        ICrudAppService< 
            CatalogDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateCatalogDto,
            CreateUpdateCatalogDto>
    {

    }
}