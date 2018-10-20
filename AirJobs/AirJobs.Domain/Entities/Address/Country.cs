using AirJobs.Domain.Entities.Base;
using System.Collections.Generic;

namespace AirJobs.Domain.Entities.Address
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
