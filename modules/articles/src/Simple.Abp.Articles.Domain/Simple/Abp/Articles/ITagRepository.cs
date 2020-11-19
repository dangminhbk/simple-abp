using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Simple.Abp.Articles
{
    public interface ITagRepository: IRepository<Tag, Guid>
    {
        Task<bool> AnyByNameAsync(string name);
    }
}
