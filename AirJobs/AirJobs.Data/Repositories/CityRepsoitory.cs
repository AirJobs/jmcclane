using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirJobs.Data.Context;
using AirJobs.Data.Repositories.Base;
using AirJobs.Domain.Entities.Address;
using AirJobs.Domain.Interfaces.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirJobs.Data.Repositories
{
    public class CityRepsoitory : BaseRepositoryAsync<City>, ICityRepository
    {
        public CityRepsoitory(AirJobsContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<City>> ListByState(Guid stateId)
        {
            return await DbSet.Where(x => x.StateId == stateId).OrderBy(x => x.Name).ToListAsync();
        }
    }
}