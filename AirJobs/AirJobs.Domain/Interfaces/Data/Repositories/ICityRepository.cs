using AirJobs.Domain.Entities.Addresses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirJobs.Domain.Interfaces.Data.Repositories
{
    public interface ICityRepository : IBaseRepositoryAsync<City>
    {
        Task<List<City>> ListByState(Guid stateId);
    }
}
