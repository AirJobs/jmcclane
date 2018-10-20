using AirJobs.Domain.Entities.Base;
using System;

namespace AirJobs.Domain.Entities.User
{
    public class Scheduling : BaseEntity
    {
        public DateTime JobDate { get; set; }
        public Guid JobId { get; set; }
        public Guid UserId { get; set; }

        public virtual Job.Job Job { get; set; }
        public virtual User User { get; set; }
    }
}
