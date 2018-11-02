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
    public class StateRepository : BaseRepositoryAsync<State>, IStateRepository
    {
        public StateRepository(AirJobsContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<State>> ListByCountry(Guid countryId)
        {
            return await DbSet.Where(x => x.CountryId == countryId).OrderBy(x => x.Name).ToListAsync();
        }
    }
}