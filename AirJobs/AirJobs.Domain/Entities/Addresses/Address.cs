using System;
using System.Collections.Generic;
using AirJobs.Domain.Entities.Base;
using AirJobs.Domain.Entities.Jobs;
using AirJobs.Domain.Entities.Users;
using GeoCoordinatePortable;

namespace AirJobs.Domain.Entities.Addresses
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
        public virtual User User { get; set; }
        public virtual IEnumerable<Job> Jobs { get; set; }
    }
}
