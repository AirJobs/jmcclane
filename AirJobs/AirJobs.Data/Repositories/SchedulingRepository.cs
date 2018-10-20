using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirJobs.Data.Context;
using AirJobs.Data.Repositories.Base;
using AirJobs.Domain.Entities.User;
using AirJobs.Domain.Interfaces.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirJobs.Data.Repositories
{
    public class SchedulingRepository : BaseRepositoryAsync<Scheduling>, ISchedulingRepository
    {
        public SchedulingRepository(AirJobsContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Scheduling>> ListByUser(Guid userId)
        {
            return await DbSet.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}