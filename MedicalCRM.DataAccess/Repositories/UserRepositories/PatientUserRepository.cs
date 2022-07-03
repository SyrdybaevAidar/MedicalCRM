using MedicalCRM.DataAccess.Contexts;
using MedicalCRM.DataAccess.Entities.UserEntities;
using MedicalCRM.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Repositories.UserRepositories {
    public class PatientUserRepository : UserRepository<PatientUser>, IPatientUserRepository {
        public PatientUserRepository(ApplicationDbContext context) : base(context) {
        }

        public async Task<PatientUser?> GetByIdWithNavigations(int id) {
            return await All.Where(i => i.Id == id)
                .Include(i => i.BloodType)
                .Include(i => i.DoctorUser)
                .Include(i => i.Consultations.Where(i => i.Diseases != null))
                .FirstOrDefaultAsync();
        }

        public async Task<(List<PatientUser> Users, int Count)> GetFilteredPatientsQuery(PatientFilter filter) {
            var query = GetFilteredUsersQuery(filter)
                .Where(i => i.DoctorUserId == filter.DoctorId);

            var count = await query.CountAsync();
            var users = await query.OrderBy(i => i.UserName)
                .Skip(filter.PageSize * (filter.Page - 1))
                .Take(filter.PageSize)
                .ToListAsync();

            return (users, count);
        }
    }
}
