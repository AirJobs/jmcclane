using System;

namespace AirJobs.Models.Dtos.State
{
    public class StateListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UF { get; set; }
        public Guid CountryId { get; set; }
    }
}
