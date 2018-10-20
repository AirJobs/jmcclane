using System;

namespace AirJobs.Models.Dtos.Job
{
    public class JobListDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
