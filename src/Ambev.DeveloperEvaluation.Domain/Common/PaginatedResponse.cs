namespace Ambev.DeveloperEvaluation.Domain.Common
{
    public class PaginatedResponse<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
    }
}
