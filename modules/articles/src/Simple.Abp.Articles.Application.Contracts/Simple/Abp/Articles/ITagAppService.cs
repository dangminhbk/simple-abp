using Simple.Abp.Articles.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Articles
{
    public interface ITagAppService :
        ICrudAppService< 
            TagDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateTagDto,
            CreateUpdateTagDto>
    {
        Task<List<TagDto>> GetAllAsync();
    }
}