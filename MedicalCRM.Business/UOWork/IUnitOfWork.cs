using MedicalCRM.DataAccess.Entities;
using MedicalCRM.DataAccess.Entities.UserEntities;
using MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities;
using MedicalCRM.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.UOWork {
    public interface IUnitOfWork {
        IRepository<Consultation> Consultations { get; }
        IRepository<DoctorDetails> DoctorDetails { get; }
        IRepository<Position> Positions { get; }
        IRepository<BloodType> BloodTypes { get; }
        IChatRepository Chat { get;}
        IDoctorUserRepository Doctors { get; }
        IPatientUserRepository Patients { get; }
        IRepository<Message> Messages { get; }
        IRepository<Recept> Recepts { get; }
        IRepository<ReceptByMedicament> ReceptByMedicaments { get; }
        IRepository<AdminUser> Admins { get; }

        Task SaveChangesAsync();

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task CommitTransactionsAsync();

        Task RollbackTransationsAsync();
    }
}
