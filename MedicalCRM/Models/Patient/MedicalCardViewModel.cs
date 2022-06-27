using MedicalCRM.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace MedicalCRM.Models.Patient {
    public class MedicalCardViewModel {
        public int MedicalCardId { get; set; }
        [Display(Name = "Семейный врач")]
        public string FamilyDoctorName { get; set; }
        [Display(Name = "Группа крови")]
        public int BloodTypeId { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        public int PatientId { get; set; }
    }
}
