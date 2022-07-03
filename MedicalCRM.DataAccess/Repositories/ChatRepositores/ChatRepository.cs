using MedicalCRM.DataAccess.Contexts;
using MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities;
using MedicalCRM.DataAccess.Exceptions;
using MedicalCRM.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Repositories.ChatRepositores {
    public class ChatRepository : Repository<Chat>, IChatRepository {
        public ChatRepository(ApplicationDbContext context) : base(context) {
        }

        public override async Task<Chat?> InsertAsync(Chat entity) {
            var result = await GetByPatientAndDoctorIdsAsync(entity.PatientId, entity.DoctorId);
            if (result is not null) {
                return result;
            }
            var insertResult = await base.InsertAsync(entity);
            return insertResult;
        }
        public async Task<Chat?> GetByPatientAndDoctorIdsAsync(int patientId, int doctorId) {
            var result = await All
                .Include(i => i.Patient)
                .Include(i => i.Doctor)
                .Where(i => i.PatientId == patientId && i.DoctorId == doctorId)
                .Include(i => i.Messages.OrderBy(i => i.SendDate))
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Chat>> GetChatsByDoctorIdAsync(int id) {
            return await All.Where(i => i.DoctorId == id)
                .Include(i => i.Messages.Where(i => i.Id == id)
                .OrderByDescending(i => i.SendDate).Take(1))
                .Include(i => i.Doctor)
                .Include(i => i.Patient)
                .OrderBy(i => i.Messages != null).ThenByDescending(i => i.Messages.OrderByDescending(i => i.SendDate))
                .ToListAsync();
        }

        public async Task<List<Chat>> GetChatsByPatientIdAsync(int id) {
            try {
                return await All.Where(i => i.PatientId == id)
                    .Include(i => i.Messages.Where(i => i.Id == id)
                    .OrderByDescending(i => i.SendDate).Take(1))
                    .Include(i => i.Doctor)
                    .Include(i => i.Patient)
                    .ToListAsync();
            } catch (Exception e) {
                throw e;
            }
        }

        public override async Task<Chat?> GetByIdAsync(int id) {
            var result = await All.Where(i => i.Id == id)
                .Include(i => i.Patient)
                .Include(i => i.Doctor)
                .Include(i => i.Messages.OrderByDescending(i => i.SendDate))
                .FirstOrDefaultAsync();
            return result;
        }
    }
}
