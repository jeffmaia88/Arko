using Arko.Core.Models;
using Arko.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Handlers
{
    public interface ICurrentStockHandler
    {
        Task<Response<CurrentStock>> AddToStockAsync(string patrimony);
        Task<Response<CurrentStock>> RemoveFromStockAsync(string patrimony);
    }
}
