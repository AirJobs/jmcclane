using AirJobs.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace AirJobs.Domain.Entities.Address
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public Guid StateId { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual State State { get; set; }
    }
}
