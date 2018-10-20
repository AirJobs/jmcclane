using AirJobs.Domain.Entities.Job;
using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirJobs.Domain.Interfaces.Data.Repositories
{
    public interface IJobRepository : IBaseRepositoryAsync<Job>
    {
        List<Job> SearchAndPaginate(string cityName, GeoCoordinate geo, int page, int size, out int total);
        Task<List<Job>> ListFavoritesByUser(Guid userId);
    }
}