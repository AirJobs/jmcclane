using AirJobs.Domain.Interfaces.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace AirJobs.Domain.Interfaces.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IJobRepository Job { get; }
        ISchedulingRepository Scheduling { get; }
        IFavoriteRepository Favorite { get; }
        IEvaluationRepository Evaluation { get; }
        IAddressRepository Address { get; }
        ICityRepository City { get; }
        IStateRepository State { get; }
        ICountryRepository Country { get; }

        bool Save();
        Task<bool> SaveAsync();
    }
}