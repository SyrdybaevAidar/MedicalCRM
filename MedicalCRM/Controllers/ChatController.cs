using AutoMapper;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.DataAccess.Enums;
using MedicalCRM.Hubs;
using MedicalCRM.Models;
using MedicalCRM.Models.ChatModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace MedicalCRM.Controllers {
    [Authorize]
    public class ChatController : BaseController {
        private readonly ILogger<ChatController> _logger;
        private readonly IChatService _chatService;
        private readonly ICustomUserManager _customUserManager;
        private readonly IMapper _mapper;

        public ChatController(ILogger<ChatController> logger, ICustomUserManager customUserManager, IChatService chatService, IMapper mapper) {
            _logger = logger;
            _customUserManager = customUserManager;
            _chatService = chatService;
            _mapper = mapper;
        }

        public IActionResult Index() {
            var result = _chatService.GetChatByPatientId(CurrentUserId);
            return View();
        }

        public async Task<IActionResult> Private(int receiverId) {
            var userType = await _customUserManager.GetUserTypeById(CurrentUserId);
            var doctorId = userType == UserType.Doctor ? CurrentUserId : receiverId;
            var patientId = userType == UserType.Patient ? CurrentUserId : receiverId;
            var chat = await _chatService.CreateOrGetChatAsyncOr(patientId, doctorId);
            var model = new PrivateChatModel();
            if (CurrentUserId == patientId) {
                model.ReceiverName = chat.DoctorUser.UserName;
                model.SenderName = chat.PatientUser.UserName;
                model.ReceiverFullName = chat.DoctorUser.GetFullName();
            } else {
                model.ReceiverName = chat.PatientUser.UserName;
                model.SenderName = chat.DoctorUser.UserName;
                model.ReceiverFullName = chat.PatientUser.GetFullName();
            }
            if (chat.Messages.Count() > 0) {
                chat.Messages = chat.Messages.Select(i => {
                    i.IsCurrentUserMessage = i.UserId == CurrentUserId;
                    return i;
                }).ToList();
            }
            model.Messages = chat.Messages;

            return View("Private2", model);
        }

        private async Task<IActionResult> Create(int receiveUserId) {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}