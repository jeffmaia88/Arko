using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public CurrentStock? CurrentStock { get; set; }
        public Discharge? Discharge { get; set; }

        public IList<Entry> Entries { get; set; } =  new List<Entry>();

        public IList<Exit> Exits { get; set; } = new List<Exit>();

    }
}
