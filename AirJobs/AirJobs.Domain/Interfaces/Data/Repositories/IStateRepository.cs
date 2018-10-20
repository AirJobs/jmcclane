using AirJobs.Domain.Entities.Address;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirJobs.Domain.Interfaces.Data.Repositories
{
    public interface IStateRepository : IBaseRepositoryAsync<State>
    {
        Task<IEnumerable<State>> ListByCountry(Guid countryId);
    }
}
