using AutoMapper;
using MedicalCRM.Business.Models;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.Business.UOWork;
using MedicalCRM.DataAccess.Entities.UserEntities;
using MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services {
    public class ChatService: IChatService {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _customUserManager;

        public ChatService(IUnitOfWork uow, IMapper mapper, UserManager<User> customUserManager) {
            _uow = uow;
            _mapper = mapper;
            _customUserManager = customUserManager;
        }

        public async Task<ChatDTO> CreateOrGetChatAsyncOr(int patientId, int doctorId) {
            var entity = new Chat() { 
                DoctorId = doctorId,
                PatientId = patientId
            };
            
            await _uow.Chat.InsertAsync(entity);
            await _uow.SaveChangesAsync();

            var entityWithNavs = await _uow.Chat.GetByPatientAndDoctorIdsAsync(patientId, doctorId);
            var result = _mapper.Map<ChatDTO>(entityWithNavs);
            return result;
        }

        public async Task<MessageDTO> CreateMessage(MessageDTO dto) {
            var senderUser =await  _customUserManager.FindByNameAsync(dto.SenderName);
            var receiverUser = await _customUserManager.FindByNameAsync(dto.ReceiverName);
            var patientId = senderUser.UserType == DataAccess.Enums.UserType.Patient ? senderUser.Id : receiverUser.Id;
            var doctorId = senderUser.UserType == DataAccess.Enums.UserType.Doctor ? senderUser.Id : receiverUser.Id;
            var chat = await  _uow.Chat.GetByPatientAndDoctorIdsAsync(patientId, doctorId);
            var entity = new Message() { ChatId = chat.Id, SendDate = DateTime.Now, UserId = senderUser.Id, Text = dto.Text};
            var result = await _uow.Messages.InsertAsync(entity);
            await _uow.SaveChangesAsync();
            return dto;
        }

        public async Task<List<ChatDTO>?> GetChatByDoctorId(int id) {
            var entities = await _uow.Chat.GetChatsByDoctorIdAsync(id);
            return _mapper.Map<List<ChatDTO>>(entities);
        }

        public async Task<List<ChatDTO>?> GetChatByPatientId(int id) {
            var entities = await _uow.Chat.GetChatsByPatientIdAsync(id);
            return _mapper.Map<List<ChatDTO>>(entities);
        }

        public async Task<ChatDTO> GetChat(int id) { 
            var entity = await _uow.Chat.GetByIdAsync(id);
            return _mapper.Map<ChatDTO>(entity);
        }
    }
}
