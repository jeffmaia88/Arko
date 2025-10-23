using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Requests.Exits
{
    public class CreateExitRequest : Request
    {
        [Required(ErrorMessage = "O Setor Destino é obrigatório")]
        public string Destination { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Patrimônio é obrigatório")]
        public string Patrimony { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Data de Saída é Obrigatoria")]
        public DateTime ExitDate { get; set; }

        [Required(ErrorMessage = "O Responsável é obrigatório")]
        public int AnalystId { get; set; }


    }
}
