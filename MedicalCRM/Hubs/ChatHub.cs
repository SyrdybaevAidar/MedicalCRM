using MedicalCRM.Business.Models;
using MedicalCRM.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace MedicalCRM.Hubs {
    [Authorize]
    public class ChatHub: Hub {
        private readonly IChatService _chatService;
        public ChatHub(IChatService chatService) { 
            _chatService = chatService;
        }
        public override Task OnConnectedAsync() {
            Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
            return base.OnConnectedAsync();
        }
        public async Task SendMessage(string user, string message) {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendMessageToGroup(string sender, string receiver, string message) {
            await _chatService.CreateMessage(new MessageDTO() { ReceiverName = receiver, SenderName = sender, Text = message });
            await Clients.Group(receiver).SendAsync("ReceiveMessage", sender, message);
        }
    }
}
