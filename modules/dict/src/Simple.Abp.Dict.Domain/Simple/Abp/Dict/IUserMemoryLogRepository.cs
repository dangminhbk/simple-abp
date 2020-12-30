using System;
using Volo.Abp.Domain.Repositories;

namespace Simple.Abp.Dict
{
    public interface IUserMemoryLogRepository : IRepository<UserMemoryLog, Guid>
    {
    }
}