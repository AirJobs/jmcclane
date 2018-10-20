using AirJobs.Data.Context;
using AirJobs.Data.Repositories.Base;
using AirJobs.Domain.Entities.Address;
using AirJobs.Domain.Interfaces.Data.Repositories;

namespace AirJobs.Data.Repositories
{
    public class CountryRepository : BaseRepositoryAsync<Country>, ICountryRepository
    {
        public CountryRepository(AirJobsContext dbContext) : base(dbContext)
        {
        }
    }
}