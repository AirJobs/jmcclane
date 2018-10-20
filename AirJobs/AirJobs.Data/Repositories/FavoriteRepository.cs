using AirJobs.Data.Context;
using AirJobs.Data.Repositories.Base;
using AirJobs.Domain.Entities.User;
using AirJobs.Domain.Interfaces.Data.Repositories;

namespace AirJobs.Data.Repositories
{
    public class FavoriteRepository : BaseRepositoryAsync<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(AirJobsContext dbContext) : base(dbContext)
        {
        }
    }
}