namespace HcodeR.Infrastructure.Pagination.Pagination
{
    public class PaginationFilter
    {
        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;

            Validate();
        }

        private void Validate()
        {
            ValidatePageNumber();
            ValidatePageSize();
        }

        private void ValidatePageNumber()
        {
            PageNumber = PageNumber <= 1 ? 1 : PageNumber;
        }

        private void ValidatePageSize()
        {
            PageSize = PageSize == 0 || PageSize > 10 ? 10 : PageSize;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Filter { get; set; }
    }
}
