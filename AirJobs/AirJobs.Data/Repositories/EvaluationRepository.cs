using AirJobs.Data.Context;
using AirJobs.Data.Repositories.Base;
using AirJobs.Domain.Entities.Jobs;
using AirJobs.Domain.Interfaces.Data.Repositories;

namespace AirJobs.Data.Repositories
{
    public class EvaluationRepository : BaseRepositoryAsync<Evaluation>, IEvaluationRepository
    {
        public EvaluationRepository(AirJobsContext dbContext) : base(dbContext)
        {
        }
    }
}
