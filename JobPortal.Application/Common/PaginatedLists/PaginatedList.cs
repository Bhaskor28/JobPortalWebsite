namespace JobPortal.Application.Common.PaginatedLists
{
    public class PaginatedList<T> : List<T>
    {
        public List<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalItems = count;
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);
            Items = items;

        }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public int FirstItemIndex => (PageIndex - 1) * PageSize;
        public int LastItemIndex => Math.Min(PageIndex * PageSize, TotalItems);

        public static PaginatedList<T> CreatePagination(IQueryable<T> source, int pageIndex, int padeSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * padeSize).Take(padeSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, padeSize);
        }
    }
}
