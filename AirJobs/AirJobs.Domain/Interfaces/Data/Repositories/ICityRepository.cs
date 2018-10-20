using AirJobs.Domain.Entities.Address;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirJobs.Domain.Interfaces.Data.Repositories
{
    public interface ICityRepository : IBaseRepositoryAsync<City>
    {
        Task<IEnumerable<City>> ListByState(Guid stateId);
    }
}
