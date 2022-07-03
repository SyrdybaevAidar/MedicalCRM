using MedicalCRM.Business.Models;
using MedicalCRM.Models.ChatModels.MessageModels;

namespace MedicalCRM.Models.ChatModels {
    public class PrivateChatModel {

        public PrivateChatModel() { 
        
        }
        public PrivateChatModel(string senderName, string receiverName, string senderFullName, string receiverFullName) {
            SenderName = senderName;
            ReceiverName = receiverName;
            SenderFullName = senderFullName;
            ReceiverFullName = receiverFullName;
        }

        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverFullName { get; set; }
        public string SenderFullName { get; set; }

        public List<MessageDTO> Messages;
    }
}
