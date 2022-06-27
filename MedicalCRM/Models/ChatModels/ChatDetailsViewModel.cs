using MedicalCRM.Models.ChatModels.MessageModels;

namespace MedicalCRM.Models.ChatModels {
    public class ChatDetailsViewModel {
        public int ChatId { get; set; }
        public string PatientUserName { get; set; }
        public string DoctorUserName { get; set; }

        public List<MessageIndexViewModel> Messages;
    }
}
