using System;
using Volo.Abp.Domain.Repositories;

namespace Simple.Abp.Dict
{
    public interface IWordRepository : IRepository<Word, Guid>
    {
    }
}