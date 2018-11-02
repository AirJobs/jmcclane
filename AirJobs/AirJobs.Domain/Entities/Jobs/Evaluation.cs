using AirJobs.Domain.Entities.Base;
using AirJobs.Domain.Entities.Jobs.Enumns;
using AirJobs.Domain.Entities.Users;
using System;

namespace AirJobs.Domain.Entities.Jobs
{
    public class Evaluation : BaseEntity
    {
        public EvaluationStarEnum Stars { get; set; }
        public string Description { get; set; }
        public Guid JobId { get; set; }
        public Guid UserId { get; set; }
        public Guid SchedulingId { get; set; }

        public virtual Job Job { get; set; }
        public virtual User User { get; set; }
        public virtual Scheduling Scheduling { get; set; }
    }
}
