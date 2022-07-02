using MedicalCRM.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace MedicalCRM.Models.Patient {
    public class ConsultationViewModel {
        public int ConsultationId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        [Display(Name = "Доктор")]
        public string DoctorName{ get; set; }
        [Display(Name = "Пациент")]
        public string PatientName { get; set; }
        [Display(Name = "Диагноз")]
        public string Diseases { get; set; }
        [Display(Name = "Рекомендации")]
        public string Recommendations { get; set; }
        [Display(Name = "Дата приема")]
        public DateTime Date { get; set; }
        public Recept Recept { get; set; }
    }
}
