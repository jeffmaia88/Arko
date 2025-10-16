using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Models
{
    public class Analyst
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public IList<Entry>? Entries { get; set; }
        public IList<Exit>? Exits { get; set; }
    }
}
