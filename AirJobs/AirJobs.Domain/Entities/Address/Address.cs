using AirJobs.Domain.Entities.Base;
using GeoCoordinatePortable;
using System;
using System.Collections.Generic;

namespace AirJobs.Domain.Entities.Address
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public virtual GeoCoordinate GeoLocation { get; set; }
        public Guid UserId { get; set; }
        public Guid CityId { get; set; }

        public virtual City City { get; set; }
        public virtual User.User User { get; set; }
        public virtual IEnumerable<Job.Job> Jobs { get; set; }
    }
}
