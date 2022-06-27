using MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Repositories.Interfaces {
    public interface IChatRepository: IRepository<Chat> {
        Task<Chat> InsertAsync(Chat entity);
        Task<Chat?> GetByPatientAndDoctorIdsAsync(int patientId, int doctorId);
        Task<List<Chat>> GetChatsByDoctorIdAsync(int id);
        Task<List<Chat>> GetChatsByPatientIdAsync(int id);
    }
}
