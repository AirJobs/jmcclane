using System;
using System.ComponentModel.DataAnnotations;

namespace AirJobs.Models.Dtos.Address
{
    public class AddressCreateDto
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string Neighborhood { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public Guid CityId { get; set; }
    }
}
