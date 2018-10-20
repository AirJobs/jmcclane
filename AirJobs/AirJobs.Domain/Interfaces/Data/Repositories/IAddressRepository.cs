using AirJobs.Domain.Entities.Address;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirJobs.Domain.Interfaces.Data.Repositories
{
    public interface IAddressRepository : IBaseRepositoryAsync<Address>
    {
        Task<IEnumerable<Address>> ListByCity(Guid cityId);
        Task<IEnumerable<Address>> ListByUser(Guid userId);
    }
}
