namespace MedicalCRM.Models.ChatModels {
    public class ChatIndexViewModel {
        public int Id { get; set; }
        public string PatientUserName { get; set; }
        public string DoctorUserName { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string LastMessage { get; set; } 
    }
}
