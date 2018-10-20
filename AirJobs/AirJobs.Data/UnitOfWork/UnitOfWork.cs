using AirJobs.Data.Context;
using AirJobs.Data.Repositories;
using AirJobs.Domain.Interfaces.Data.Repositories;
using AirJobs.Domain.Interfaces.Data.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace AirJobs.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository User => _user ?? (_user = new UserRepsoitory(DbContext));
        public IJobRepository Job => _job ?? (_job = new JobRepository(DbContext));
        public ISchedulingRepository Scheduling => _scheduling ?? (_scheduling = new SchedulingRepository(DbContext));
        public IFavoriteRepository Favorite => _favorite ?? (_favorite = new FavoriteRepository(DbContext));
        public IAddressRepository Address => _address ?? (_address = new AddressRepository(DbContext));
        public ICityRepository City => _city ?? (_city ?? new CityRepsoitory(DbContext));
        public IStateRepository State => _state ?? (_state = new StateRepository(DbContext));
        public ICountryRepository Country => _country ?? (_country = new CountryRepository(DbContext));

        public bool Save()
        {
            return DbContext.SaveChanges() > 0;
        }

        public async Task<bool> SaveAsync()
        {
            var result = await DbContext.SaveChangesAsync();
            return result > 0;
        }

        #region Constructor / Fields

        private readonly AirJobsContext DbContext;

        public UnitOfWork(AirJobsContext dbContext)
        {
            DbContext = dbContext;
        }

        #endregion

        #region Private Repositories

        private IUserRepository _user;
        private IJobRepository _job;
        private ISchedulingRepository _scheduling;
        private IFavoriteRepository _favorite;
        private IAddressRepository _address;
        private ICityRepository _city;
        private IStateRepository _state;
        private ICountryRepository _country;

        #endregion

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) DbContext?.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}