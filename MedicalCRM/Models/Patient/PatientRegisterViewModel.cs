using MedicalCRM.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedicalCRM.Models.Patient {
    public class PatientRegisterViewModel {
        [Required]
        [EmailAddress]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "ИНН")]
        [Range(0, int.MaxValue, ErrorMessage = "Инн может состоять только из цифр")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Пол")]
        public Sex Sex { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Отчество")]
        public string Patronimic { get; set; }
        [Required]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }
        [Required]
        [Display(Name = "Группа крови")]
        public int BloodTypeId { get; set; }
        [Required]
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        public int? DoctorUserId { get; set; }
    }
}
