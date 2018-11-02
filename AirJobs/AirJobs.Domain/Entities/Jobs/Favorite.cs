using AirJobs.Domain.Entities.Base;
using AirJobs.Domain.Entities.Users;
using System;

namespace AirJobs.Domain.Entities.Jobs
{
    public class Favorite : BaseEntity
    {
        public Guid JobId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual User User { get; set; }
        public virtual Job Job { get; set; }
    }
}
