using MedicalCRM.Models.Patient;

namespace MedicalCRM.Models.UserModels {
    public class DoctorMainPageViewModel {
        public List<UserIndexViewModel> Patients { get; set; }
        public List<ConsultationIndexModel> Consultations { get; set; }
    }
}
