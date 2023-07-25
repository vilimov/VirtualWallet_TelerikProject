namespace VirtualWallet.Domain.Entities
{
	public class PageResult<T>
	{
		public IList<T> Items { get; set; }
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public int TotalPages { get; set; }
		public int TotalCount { get; set; }

		public bool HasPreviousPage => (PageNumber - 1) > 0;
		public bool HasNextPage => PageNumber < TotalPages;

		public PageResult(IList<T> items, int count, int pageNumber, int pageSize)
		{
			TotalCount = count;
			PageSize = pageSize;
			PageNumber = pageNumber;
			TotalPages = (int)Math.Ceiling(count / (double)pageSize);
			Items = new List<T>(items);
		}
	}
}
