using AirJobs.Domain.Entities.Base;
using AirJobs.Domain.Entities.User;
using System;
using System.Collections.Generic;

namespace AirJobs.Domain.Entities.Job
{
    public class Job : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public Guid AddressId { get; set; }

        public virtual Address.Address Address { get; set; }
        public virtual ICollection<Scheduling> Scheduling { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
