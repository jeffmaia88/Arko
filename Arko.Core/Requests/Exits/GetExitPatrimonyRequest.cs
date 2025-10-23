using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Requests.Exits
{
    public class GetExitPatrimonyRequest : PagedRequest
    {
        public string Patrimony { get; set; } = string.Empty;
    }
}
