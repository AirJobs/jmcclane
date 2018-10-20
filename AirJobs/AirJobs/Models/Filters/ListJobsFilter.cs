using System.ComponentModel.DataAnnotations;

namespace AirJobs.Models.Filters
{
    public class ListJobsFilter
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string CityName { get; set; }

        [Required]
        public int Page { get; set; }

        [Required]
        public int Size { get; set; }
    }
}
