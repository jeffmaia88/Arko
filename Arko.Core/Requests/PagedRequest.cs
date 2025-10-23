using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Requests
{
    public class PagedRequest : Request
    {
        public int PageNumber { get; set; } = Definitions.DefaultPageNumber;
        public int PageSize { get; set; } = Definitions.DefaultPageSize;
    }
}
