using Arko.Core.Models;
using Arko.Core.Requests.Entries;
using Arko.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Handlers
{
    public interface IEntryHandler
    {
        Task<Response<Entry>> CreateAsync(CreateEntryRequest request);
        Task<PagedResponse<List<Entry>>> GetAllByPatrimonyAsync(GetEntryPatrimonyRequest request);
        Task<PagedResponse<List<Entry>>> GetAllAsync(GetAllEntriesRequest request);

    }
}
