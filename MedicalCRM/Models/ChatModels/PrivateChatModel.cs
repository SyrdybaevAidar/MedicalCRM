using MedicalCRM.Business.Models;
using MedicalCRM.Models.ChatModels.MessageModels;

namespace MedicalCRM.Models.ChatModels {
    public class PrivateChatModel {
        public PrivateChatModel(string senderName, string receiverName) {
            SenderName = senderName;
            ReceiverName = receiverName;
        }

        public string SenderName { get; set; }
        public string ReceiverName { get; set; }

        public List<MessageDTO> Messages;
    }
}
