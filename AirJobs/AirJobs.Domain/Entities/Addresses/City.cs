using System;
using System.Collections.Generic;
using AirJobs.Domain.Entities.Base;

namespace AirJobs.Domain.Entities.Addresses
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public Guid StateId { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual State State { get; set; }
    }
}
