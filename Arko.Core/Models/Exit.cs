using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Models
{
    public class Exit
    {
        public int Id { get; set; }
        public string Destination { get; set; } = string.Empty;
        public DateTime ExitDate { get; set; }
        public Analyst Responsible { get; set; } = null!;
        public Equipment Equipment { get; set; } = null!;
        public int IdEquipment { get; set; }
        public int IdAnalyst { get; set; }

    }
}
