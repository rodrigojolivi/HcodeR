namespace HcodeR.Application.Dtos.Pagination
{
    public class PaginationFilterDto
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string Filter { get; set; }
    }
}
