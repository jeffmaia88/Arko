using Arko.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Requests.Entries
{
   public class CreateEntryRequest : Request
    {
        [Required(ErrorMessage = "O Setor Origem é obrigatório")]
        public string Origin { get; set; } = string.Empty;

        [Required(ErrorMessage = "Data Inválida")]
        public DateTime EntryDate { get; set; }

        [Required(ErrorMessage = "O Responsável é obrigatório")]
        public int AnalystId { get; set; }

        [Required(ErrorMessage = "O Patrimônio é obrigatório")]
        public string Patrimony { get; set; } = string.Empty;        

    }
}
