using System;
using Simple.Abp.Dict.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Dict
{
    public interface IUserMemoryLogAppService :
        ICrudAppService< 
            UserMemoryLogDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateUserMemoryLogDto,
            CreateUpdateUserMemoryLogDto>
    {

    }
}