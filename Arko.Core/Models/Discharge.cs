using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Models
{
    public class Discharge
    {
        public int Id { get; set; }
        public DateTime DateDischarge { get; set; }
        public string Reason { get; set; } = string.Empty;
        public Equipment? Equipment { get; set; }
        public int EquipmentId { get; set; }
    }
}
