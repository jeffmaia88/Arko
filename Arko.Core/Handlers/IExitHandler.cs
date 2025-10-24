using Arko.Core.Models;
using Arko.Core.Requests.Exits;
using Arko.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Handlers
{
    public interface IExitHandler 
    {
        Task<Response<Exit>> CreateAsync(CreateExitRequest request);
        Task<PagedResponse<List<Exit>>> GetAllExitsAsync (GetAllExitsRequest request);
        Task<PagedResponse<List<Exit>>> GetAllExitPatrimonyAsync (GetAllExitPatrimonyRequest request);
    }
}
