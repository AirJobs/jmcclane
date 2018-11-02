using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirJobs.Data.Context;
using AirJobs.Data.Repositories.Base;
using AirJobs.Domain.Entities.Jobs;
using AirJobs.Domain.Interfaces.Data.Repositories;
using GeoCoordinatePortable;
using Microsoft.EntityFrameworkCore;

namespace AirJobs.Data.Repositories
{
    public class JobRepository : BaseRepositoryAsync<Job>, IJobRepository
    {
        public JobRepository(AirJobsContext context) : base(context)
        {
        }

        public List<Job> SearchAndPaginate(string cityName, GeoCoordinate geo, int page, int size, out int total)
        {
            var queryJob = DbSet.AsQueryable();
            total = Queryable.Count(queryJob);

            if (!string.IsNullOrEmpty(cityName)) queryJob = SearchForCity(queryJob, cityName);

            queryJob = QueryClosest(queryJob, geo);

            return Paginate(queryJob, page, size);
        }

        public async Task<List<Job>> ListFavoritesByUser(Guid userId)
        {
            return await DbContext
                .Favorite
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => x.Job)
                .ToListAsync();
        }

        private IQueryable<Job> QueryClosest(IQueryable<Job> queryJob, GeoCoordinate geo)
        {
            return queryJob.OrderBy(job => job.Address.GeoLocation.GetDistanceTo(geo));
        }

        private IQueryable<Job> SearchForCity(IQueryable<Job> queryJob, string cityName)
        {
            return queryJob.Where(x =>
                x.Address.City.Name.Equals(cityName.Trim(), StringComparison.CurrentCultureIgnoreCase));
        }
    }
}