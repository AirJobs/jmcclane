using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirJobs.Domain.Entities.Addresses;

namespace AirJobs.Domain.Interfaces.Data.Repositories
{
    public interface IAddressRepository : IBaseRepositoryAsync<Address>
    {
        Task<IEnumerable<Address>> ListByCity(Guid cityId);
        Task<IEnumerable<Address>> ListByUser(Guid userId);
    }
}
