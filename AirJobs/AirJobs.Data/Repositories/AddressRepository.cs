using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirJobs.Data.Context;
using AirJobs.Data.Repositories.Base;
using AirJobs.Domain.Entities.Addresses;
using AirJobs.Domain.Interfaces.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirJobs.Data.Repositories
{
    public class AddressRepository : BaseRepositoryAsync<Address>, IAddressRepository
    {
        public AddressRepository(AirJobsContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Address>> ListByCity(Guid cityId)
        {
            return await DbSet.Where(x => x.CityId == cityId).OrderBy(x => x.Street).ToListAsync();
        }

        public async Task<IEnumerable<Address>> ListByUser(Guid userId)
        {
            return await DbSet.Where(x => x.UserId == userId).OrderBy(x => x.Street).ToListAsync();
        }
    }
}