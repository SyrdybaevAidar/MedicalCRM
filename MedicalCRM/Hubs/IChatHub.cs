namespace MedicalCRM.Hubs {
    public interface IChatHub {
        Task SendToUser(string user, string receiverConnectionId, string message);
    }
}
