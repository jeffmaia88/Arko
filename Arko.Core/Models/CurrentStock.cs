using Arko.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Models
{
    public class CurrentStock
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public Equipment Equipment { get; set; } = null!;
        public int IdEquipment { get; set; }
    }
}
