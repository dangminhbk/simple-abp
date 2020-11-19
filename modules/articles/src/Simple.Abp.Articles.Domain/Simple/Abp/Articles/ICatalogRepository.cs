using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace Simple.Abp.Articles
{
    public interface ICatalogRepository : IRepository<Catalog, Guid>
    {
    }
}
