using System.ComponentModel.DataAnnotations;

namespace MedicalCRM.Models.UserModels {
    public class UserUpdateViewModel: UserRegistrationViewModel {
        public int Id { get; set; }
    }
}
