namespace Demo.Repository.DTO
{
    public class Paging
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }

    public class TotalRecord
    {
        public int TotalCount { get; set; }
    }
}
