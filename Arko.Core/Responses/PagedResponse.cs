using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Arko.Core.Responses
{
    public class PagedResponse<TData> : Response<TData>
    {
        [JsonConstructor]
        public PagedResponse(TData? data, int totalCount, int currentPage = Definitions.DefaultPageNumber, int pageSize = Definitions.DefaultPageSize) : base(data)
        {
            Data = data;
            TotalCount = totalCount;
            CurrentPage = Definitions.DefaultPageNumber;
            PageSize = pageSize;
        }

        public PagedResponse(TData? data, int code = Definitions.DefaultStatusCode, string? message = null) : base(data, code, message)
        {

        }

        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        public int PageSize { get; set; }
        public int TotalCount { get; set; }

    }
}
