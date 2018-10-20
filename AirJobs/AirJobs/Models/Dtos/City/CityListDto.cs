using System;

namespace AirJobs.Models.Dtos.City
{
    public class CityListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid StateId { get; set; }

    }
}
