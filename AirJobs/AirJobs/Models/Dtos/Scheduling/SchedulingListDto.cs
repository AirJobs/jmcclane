using System;

namespace AirJobs.Models.Dtos.Scheduling
{
    public class SchedulingListDto
    {
        public Guid Id { get; set; }
        public DateTime JobDate { get; set; }
        public Guid JobId { get; set; }
    }
}
