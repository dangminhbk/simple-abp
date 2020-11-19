using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Articles
{
    [RemoteService]
    [Area("Articles")]
    [ControllerName("Catalog")]
    [Route("api/catalog")]
    public class CatalogController : AbpController, ICatalogAppService
    {
        private readonly ICatalogAppService _catalogAppService;
        public CatalogController(ICatalogAppService catalogAppService)
        {
            _catalogAppService = catalogAppService;
        }

        [HttpPost]
        public Task<CatalogDto> CreateAsync(CreateUpdateCatalogDto input)
        {
            return _catalogAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _catalogAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<CatalogDto> GetAsync(Guid id)
        {
            return _catalogAppService.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<CatalogDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return _catalogAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("get-tree")]
        public Task<List<CatalogDto>> GetTreeAsync()
        {
            return _catalogAppService.GetTreeAsync();
        }

        [HttpPut]
        [Route("{id}")]
        public Task<CatalogDto> UpdateAsync(Guid id, CreateUpdateCatalogDto input)
        {
            return _catalogAppService.UpdateAsync(id, input);
        }
    }
}
