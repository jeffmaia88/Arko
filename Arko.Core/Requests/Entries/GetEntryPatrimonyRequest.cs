using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Requests.Entries
{
    public  class GetEntryPatrimonyRequest : PagedRequest
    {
        public string Patrimony { get; set; }
    }
}
