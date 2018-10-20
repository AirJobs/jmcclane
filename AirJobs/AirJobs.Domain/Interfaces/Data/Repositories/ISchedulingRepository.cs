using AirJobs.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirJobs.Domain.Interfaces.Data.Repositories
{
    public interface ISchedulingRepository : IBaseRepositoryAsync<Scheduling>
    {
        Task<List<Scheduling>> ListByUser(Guid userId);
    }
}
