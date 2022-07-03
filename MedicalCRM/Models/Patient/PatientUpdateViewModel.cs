using MedicalCRM.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedicalCRM.Models.Patient {
    public class PatientUpdateViewModel {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "ИНН")]
        [RegularExpression(@"^-?[0-9][0-9,\.]+$", ErrorMessage = "Инн может состоять только из цифр")]
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
        [Required]
        [Display(Name = "Id паспорта")]
        public string PassportId { get; set; }
        public int? DoctorUserId { get; set; }
    }
}
