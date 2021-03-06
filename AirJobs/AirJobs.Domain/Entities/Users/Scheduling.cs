﻿using AirJobs.Domain.Entities.Base;
using AirJobs.Domain.Entities.Jobs;
using System;

namespace AirJobs.Domain.Entities.Users
{
    public class Scheduling : BaseEntity
    {
        public DateTime JobDate { get; set; }
        public Guid JobId { get; set; }
        public Guid UserId { get; set; }

        public virtual Job Job { get; set; }
        public virtual User User { get; set; }
        public virtual Evaluation Evaluation { get; set; }
    }
}
