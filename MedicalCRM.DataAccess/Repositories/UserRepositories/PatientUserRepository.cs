using MedicalCRM.DataAccess.Context;
using MedicalCRM.DataAccess.Entities.UserEntities;
using MedicalCRM.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Repositories.UserRepositories {
    public class PatientUserRepository : Repository<PatientUser>, IPatientUserRepository {
        public PatientUserRepository(ApplicationDbContext context) : base(context) {
        }

        public async Task<PatientUser?> GetByIdWithNavigations(int id) {
            return await All.Where(i => i.Id == id)
                .Include(i => i.BloodType)
                .Include(i => i.DoctorUser)
                .Include(i => i.Consultations.Where(i => i.Diesases != null))
                .FirstOrDefaultAsync();
        }
    }
}
