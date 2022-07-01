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
    public class DoctorUserRepository : UserRepository<DoctorUser>, IDoctorUserRepository {
        public DoctorUserRepository(ApplicationDbContext context) : base(context) {
        }

        public async Task<DoctorUser?> GetDoctorWithNavigationAsync(int DoctorId) {
            return await All.Where(i => i.Id == DoctorId)
                .Include(i => i.DoctorDetails).ThenInclude(i => i.Position)
                .FirstOrDefaultAsync();
        }

        public async Task<List<int>> GetDoctorIds() {
            return await All.Select(i => i.Id).ToListAsync();
        }

        public async Task<(List<DoctorUser> Users, int Count)> GetFilteredPatientsQuery(UserFilterView filter) {
            var query = GetFilteredUsersQuery(filter);

            var count = await query.CountAsync();
            var users = await query.OrderBy(i => i.UserName)
                .Skip(filter.PageSize * (filter.Page - 1))
                .Take(filter.PageSize)
                .ToListAsync();

            return (users, count);
        }
    }
}
