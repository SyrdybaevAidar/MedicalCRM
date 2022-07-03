using MedicalCRM.Business.Models;
using MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities;
using MedicalCRM.Models.Patient;

namespace MedicalCRM.Models.UserModels {
    public class PatientMainPageIndexModel {
        public List<UserIndexViewModel> Doctors { get; set; }
        public List<ConsultationIndexModel> Consultations { get; set; }
        public MessageDTO LastMessage { get; set; }
    }
}
