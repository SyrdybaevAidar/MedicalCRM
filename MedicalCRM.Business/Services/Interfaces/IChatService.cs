using MedicalCRM.Business.Models;
using MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services.Interfaces {
    public interface IChatService {
        Task<ChatDTO> CreateOrGetChatAsyncOr(int patientId, int doctorId);

        Task<MessageDTO> CreateMessage(MessageDTO dto);

        Task<List<ChatDTO>?> GetChatByDoctorId(int id);

        Task<List<ChatDTO>?> GetChatByPatientId(int id);
    }
}
