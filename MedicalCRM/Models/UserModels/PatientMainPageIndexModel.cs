using MedicalCRM.Models.Patient;

namespace MedicalCRM.Models.UserModels {
    public class PatientMainPageIndexModel {
        public List<UserIndexViewModel> Doctors { get; set; }
        public List<ConsultationIndexModel> Consultations { get; set; }
    }
}
