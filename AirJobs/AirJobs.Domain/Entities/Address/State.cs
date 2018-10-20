using AirJobs.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace AirJobs.Domain.Entities.Address
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
