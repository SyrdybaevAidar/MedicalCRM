using System.ComponentModel.DataAnnotations;

namespace MedicalCRM.Models.UserModels {
    public class ChangePassword {

        public string DoctorName { get; set; }
        public int DoctorId { get; set; }

        [StringLength(100, ErrorMessage = "Пароль должен содержать не меньше 6 символов", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
