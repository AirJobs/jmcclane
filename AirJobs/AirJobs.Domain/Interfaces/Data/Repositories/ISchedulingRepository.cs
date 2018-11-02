using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirJobs.Domain.Entities.Users;

namespace AirJobs.Domain.Interfaces.Data.Repositories
{
    public interface ISchedulingRepository : IBaseRepositoryAsync<Scheduling>
    {
        Task<List<Scheduling>> ListByUser(Guid userId);
    }
}
