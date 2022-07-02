using MedicalCRM.Business.Models;

namespace MedicalCRM.Models.Admin {
    public class AdminPageViewModel {
        public List<UserDTO> LastPatients { get; set; }
        public List<UserDTO> LastDoctors { get; set; }
    }
}
