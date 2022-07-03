using System.ComponentModel.DataAnnotations;

namespace MedicalCRM.Models.Patient {
    public class DiseaseIndexViewModel {
        public int Id { get; set; }
        [Display(Name ="Дата назначения")]
        public DateTime Date { get; set; }

        [Display(Name = "Диагноз")]
        public string Diseases { get; set; }
        [Display(Name ="Жалобы")]
        public string Complaints { get; set; }

        [Display(Name = "Доктор")]
        public string Recommendations { get; set; }
    }
}
