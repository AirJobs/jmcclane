using AirJobs.Domain.Entities.Addresses;
using AirJobs.Domain.Entities.Base;
using AirJobs.Domain.Entities.Jobs;
using AirJobs.Domain.ValueObjects;
using System.Collections.Generic;

namespace AirJobs.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public virtual Name Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Scheduling> Schedulings { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
