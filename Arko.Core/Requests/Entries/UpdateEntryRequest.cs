using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arko.Core.Requests.Entries
{
    public class UpdateEntryRequest : Request
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O Setor Origem é obrigatório")]
        public string Origin { get; set; } = string.Empty;

        [Required(ErrorMessage = "Data Inválida")]
        public DateTime EntryDate { get; set; }

        [Required(ErrorMessage = "O Responsável é obrigatório")]
        public int AnalystId { get; set; }

        [Required(ErrorMessage = "O Tipo de Equipamento é obrigatório")]
        public string EquipmentType { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Marca é obrigatória")]
        public string EquipmentBrand { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Modelo é obrigatório")]
        public string EquipmentModel { get; set; } = string.Empty;
    }
}
