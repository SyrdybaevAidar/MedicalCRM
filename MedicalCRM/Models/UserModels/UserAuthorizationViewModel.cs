using System.ComponentModel.DataAnnotations;

namespace MedicalCRM.Models.UserModels {
    public class UserAuthorizationViewModel {
        [Required]
        [Display(Name = "Логин")]
        public string UserName{ get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public string ReturnUrl => "Home/Index";
    }
}
