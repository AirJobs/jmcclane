using AirJobs.Domain.Entities.Base;
using System;

namespace AirJobs.Domain.Entities.User
{
    public class Favorite : BaseEntity
    {
        public Guid JobId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual User User { get; set; }
        public virtual Job.Job Job { get; set; }
    }
}
