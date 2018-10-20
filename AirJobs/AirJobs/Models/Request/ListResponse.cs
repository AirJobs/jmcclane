using System.Collections.Generic;

namespace AirJobs.Models.Request
{
    public class ListResponse<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
