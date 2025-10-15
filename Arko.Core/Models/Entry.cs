using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Models
{
    public  class Entry
    {
        public int Id { get; set; }
        public string Origin { get; set; } = string.Empty;
        public DateTime EntryDate { get; set; }
        public Analyst Responsible { get; set; } = null!;
        public Equipment Equipment { get; set; } = null!;
        public int IdEquipment { get; set; }
        public int IdAnalyst { get; set; }
    }
}
