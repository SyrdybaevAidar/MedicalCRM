using MedicalCRM.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedicalCRM.Models.Patient {
    public class PatientDetailsViewModel {
        public string Id { get; set; }
        [Display(Name = "Пол")]
        public Sex Sex { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string Patronimic { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Группа крови")]
        public string BloodType { get; set; }
        [Display(Name = "Адресс прописки")]
        public string Address { get; set; }
        [Display(Name = "Семейный врач")]
        public string FamilyDoctor { get; set; }
        [Required]
        [Display(Name = "ИНН")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Id паспорта")]
        public string PassportId { get; set; }
        public List<DiseaseIndexViewModel> Diseases { get; set; }
    }
}
