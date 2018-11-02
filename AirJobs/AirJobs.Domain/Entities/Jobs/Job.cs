using AirJobs.Domain.Entities.Addresses;
using AirJobs.Domain.Entities.Base;
using AirJobs.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirJobs.Domain.Entities.Jobs
{
    public class Job : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public Guid AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Scheduling> Scheduling { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }

        public int GetAverageRating()
        {
            if (!Evaluations.Any())
                return 0;

            return Evaluations.Sum(x => (int) x.Stars) / Evaluations.Count();
        }
    }
}
