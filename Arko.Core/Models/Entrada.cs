using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Models
{
    public  class Entrada
    {
        public int Id { get; set; }
        public string Origem { get; set; } = string.Empty;
        public DateTime DataEntrada { get; set; }
        public Analista Responsavel { get; set; } = null!;
        public Equipamento Equipamento { get; set; } = null!;
        public int IdEquipamento { get; set; }
        public int IdAnalista { get; set; }
    }
}
