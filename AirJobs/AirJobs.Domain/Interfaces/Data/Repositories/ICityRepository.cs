using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirJobs.Domain.Entities.Addresses;

namespace AirJobs.Domain.Interfaces.Data.Repositories
{
    public interface ICityRepository : IBaseRepositoryAsync<City>
    {
        Task<IEnumerable<City>> ListByState(Guid stateId);
    }
}
