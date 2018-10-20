using System;

namespace AirJobs.Models.Dtos.Address
{
    public class AddressListDto
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Guid CityId { get; set; }
    }
}
