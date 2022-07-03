using System.ComponentModel.DataAnnotations;

namespace MedicalCRM.Models.Patient {
    public class PatientLoginViewModel {
        [Display(Name = "Инн")]
        [Required]
        public string Inn { get; set; }
        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
    }
}
