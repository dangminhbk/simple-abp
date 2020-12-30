using System;
using Volo.Abp.Domain.Repositories;

namespace Simple.Abp.Dict
{
    public interface IUserAssignmentRepository : IRepository<UserAssignment, Guid>
    {
    }
}