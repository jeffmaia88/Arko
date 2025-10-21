using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Handlers
{
    public interface IEntryHandler
    {
        public string? Data { get; set; }
        public string Message { get; set; } = string.Empty;

    }
}
