using System;
using Simple.Abp.Dict.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Simple.Abp.Dict
{
    public class UserAssignmentRepository : EfCoreRepository<IDictDbContext, UserAssignment, Guid>, IUserAssignmentRepository
    {
        public UserAssignmentRepository(IDbContextProvider<IDictDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}