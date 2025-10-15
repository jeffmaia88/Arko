using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Models
{
    public class Saida
    {
        public int Id { get; set; }
        public string Destino { get; set; } = string.Empty;
        public DateTime DataSaida { get; set; }
        public Analista Responsavel { get; set; } = null!;
        public Equipamento MyProperty { get; set; } = null!;
        public int IdEquipamento { get; set; }
        public int IdAnalista { get; set; }

    }
}
