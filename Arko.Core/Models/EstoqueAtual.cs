using Arko.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Models
{
    public class EstoqueAtual
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public Equipamento Equipamento { get; set; } = null!;
        public int IdEquipamento { get; set; }
    }
}
