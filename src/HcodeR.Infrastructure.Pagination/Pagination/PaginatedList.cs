using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HcodeR.Infrastructure.Pagination.Pagination
{
    public class PaginatedList<T>
    {
        public PaginatedList() { }

        public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            Count = count;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            Items = new List<T>();
            Items.AddRange(items);
        }

        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; }
        public int Count { get; set; }        
        public bool HasPreviousPage { get { return PageNumber > 1; } set { } }
        public bool HasNextPage { get { return PageNumber < TotalPages; } set { } }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip(((pageNumber - 1) * pageSize)).Take(pageSize).ToListAsync();

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
