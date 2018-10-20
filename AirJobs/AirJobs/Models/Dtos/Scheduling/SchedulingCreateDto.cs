using System;
using System.ComponentModel.DataAnnotations;

namespace AirJobs.Models.Dtos.Scheduling
{
    public class SchedulingCreateDto
    {
        [Required]
        public DateTime JobDate { get; set; }

        [Required]
        public Guid JobId { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
