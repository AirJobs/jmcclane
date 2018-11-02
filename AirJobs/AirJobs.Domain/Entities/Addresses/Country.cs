using System.Collections.Generic;
using AirJobs.Domain.Entities.Base;

namespace AirJobs.Domain.Entities.Addresses
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
