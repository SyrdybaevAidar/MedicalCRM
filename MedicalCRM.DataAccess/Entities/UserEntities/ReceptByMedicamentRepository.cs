using MedicalCRM.DataAccess.Contexts;
using MedicalCRM.DataAccess.Repositories;
using MedicalCRM.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.UserEntities {
    public class ReceptByMedicamentRepository : Repository<ReceptByMedicament>, IRepository<ReceptByMedicament> {
        public ReceptByMedicamentRepository(ApplicationDbContext context) : base(context) {
        }

        public override Task<List<ReceptByMedicament>> GetAllAsync() {
            return base.GetAllAsync();
        }
    }
}
