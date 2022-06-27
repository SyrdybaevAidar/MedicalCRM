using MedicalCRM.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedicalCRM.Models.UserModels {
    public class UserRegistrationViewModel {
        [Required]
        [EmailAddress]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Логин")]
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
    }
}
