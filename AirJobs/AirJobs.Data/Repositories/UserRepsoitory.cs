using AirJobs.Data.Context;
using AirJobs.Data.Repositories.Base;
using AirJobs.Domain.Entities.Users;
using AirJobs.Domain.Interfaces.Data.Repositories;

namespace AirJobs.Data.Repositories
{
    public class UserRepsoitory : BaseRepositoryAsync<User>, IUserRepository
    {
        public UserRepsoitory(AirJobsContext dbContext) : base(dbContext)
        {
        }
    }
}