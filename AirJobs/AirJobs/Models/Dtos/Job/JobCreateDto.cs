using System;
using System.ComponentModel.DataAnnotations;

namespace AirJobs.Models.Dtos.Job
{
    public sealed class JobCreateDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Guid AddressId { get; set; }
    }
}
