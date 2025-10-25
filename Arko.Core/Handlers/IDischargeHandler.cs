using Arko.Core.Models;
using Arko.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Handlers
{
    public interface IDischargeHandler  
    {
        Task<Response<Discharge>> AddDischargeAsync(string patrimony);
        Task<Response<Discharge>> RemoveDischargeAsync(string patrimony);
    }
}
