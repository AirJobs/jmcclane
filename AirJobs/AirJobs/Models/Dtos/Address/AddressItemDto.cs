using System;

namespace AirJobs.Models.Dtos.Address
{
    public class AddressItemDto
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
    }
}
