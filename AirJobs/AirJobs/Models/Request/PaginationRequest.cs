namespace AirJobs.Models.Request
{
    public class PaginationRequest
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public PaginationRequest(int page, int size)
        {
            this.Page = page;
            this.Size = size;
        }
    }
}
