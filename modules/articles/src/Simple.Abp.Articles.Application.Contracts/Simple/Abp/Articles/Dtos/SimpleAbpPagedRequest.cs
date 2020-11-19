using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Articles.Dtos
{
    public class SimpleAbpPagedRequest : PagedAndSortedResultRequestDto
    {

        [StringLength(20)]
        public string Filter { get; set; }

        public void InitSkipCount(int pageIndex)
        {
            if (pageIndex <= 0)
                pageIndex = 1;


            SkipCount = (pageIndex - 1) * MaxResultCount;
        }
    }
}
