namespace Cambist.Core.Models
{
    public class PagedResponse<T> : ApiResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }

        // Calculated property: TotalRecords divided by PageSize, rounded up
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);
    }
}
