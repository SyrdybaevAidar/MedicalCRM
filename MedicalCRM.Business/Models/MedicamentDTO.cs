using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Models {
    public class MedicamentDTO {

        [Required]
        [Display(Name = "Количество")]
        public int Count { get; set; }
        [Required]
        [Display(Name = "Препарат")]
        public string MedicamentName { get; set; }
        [Required]
        [Display(Name = "Заметки")]
        public string Note { get; set; }
        public int ReceptId { get; set; }
    }
}
