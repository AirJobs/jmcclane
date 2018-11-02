using System;
using System.Collections.Generic;
using AirJobs.Domain.Entities.Base;

namespace AirJobs.Domain.Entities.Addresses
{
    public class State : BaseEntity
    {
        public string Name { get; set; }
        public string UF { get; set; }
        public Guid CountryId { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual Country Country { get; set; }
    }
}
