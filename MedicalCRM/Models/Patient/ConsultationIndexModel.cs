using System.ComponentModel.DataAnnotations;

namespace MedicalCRM.Models.Patient {
    public class ConsultationIndexModel {
        public int Id { get; set; }
        [Display(Name ="Доктор")]
        public string Doctor { get; set; }
        [Display(Name = "Пациент")]
        public string Patient { get; set; }
        [Display(Name = "Дата приема")]
        public DateTime Date { get; set; }
    }
}
