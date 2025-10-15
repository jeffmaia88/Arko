using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Models
{
    public class Baixa
    {
        public int Id { get; set; }
        public DateTime DataBaixa { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public Equipamento Equipamento { get; set; } = null!;
        public int IdEquipamento { get; set; }
    }
}
