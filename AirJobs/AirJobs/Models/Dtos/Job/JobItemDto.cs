using System;

namespace AirJobs.Models.Dtos.Job
{
    public class JobItemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }
        public string CountryName { get; set; }
    }
}
