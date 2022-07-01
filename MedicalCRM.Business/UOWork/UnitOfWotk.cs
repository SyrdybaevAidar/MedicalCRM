using MedicalCRM.DataAccess.Contexts;
using MedicalCRM.DataAccess.Entities;
using MedicalCRM.DataAccess.Entities.UserEntities;
using MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities;
using MedicalCRM.DataAccess.Repositories;
using MedicalCRM.DataAccess.Repositories.ChatRepositores;
using MedicalCRM.DataAccess.Repositories.Interfaces;
using MedicalCRM.DataAccess.Repositories.UserRepositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.UOWork {
    public class UnitOfWork : IUnitOfWork, IDisposable {
        private ApplicationDbContext _context;
        private readonly Lazy<IRepository<Consultation>> _consultationRepository;
        private readonly Lazy<IRepository<DoctorDetails>> _doctorDetailsRepostory;
        private readonly Lazy<IRepository<Position>> _positionRepository;
        private readonly Lazy<IRepository<BloodType>> _bloodTypesRepository;
        private readonly Lazy<IChatRepository> _chatRepository;
        private readonly Lazy<IRepository<Message>> _messageRepository;
        private readonly Lazy<IDoctorUserRepository> _doctorRepository;
        private readonly Lazy<IPatientUserRepository> _patientRepository;
        private readonly Lazy<IRepository<Recept>> _receptRepository;
        private readonly Lazy<IRepository<ReceptByMedicament>> _receptByMedicamentRepository;
        private readonly Lazy<IRepository<AdminUser>> _adminUserRepository;


        private bool _disposed;

        public IRepository<Consultation> Consultations => _consultationRepository.Value;
        public IRepository<DoctorDetails> DoctorDetails => _doctorDetailsRepostory.Value;
        public IRepository<Position> Positions => _positionRepository.Value;
        public IRepository<BloodType> BloodTypes => _bloodTypesRepository.Value;
        public IChatRepository Chat => _chatRepository.Value;
        public IRepository<Message> Messages => _messageRepository.Value;
        public IDoctorUserRepository Doctors => _doctorRepository.Value;
        public IPatientUserRepository Patients => _patientRepository.Value;
        public IRepository<Recept> Recepts => _receptRepository.Value;
        public IRepository<AdminUser> Admins => _adminUserRepository.Value;
        public IRepository<ReceptByMedicament> ReceptByMedicaments => _receptByMedicamentRepository.Value;

        public UnitOfWork(ApplicationDbContext context) {
            _context = context;
            _doctorDetailsRepostory = new Lazy<IRepository<DoctorDetails>>(() => new Repository<DoctorDetails>(context));
            _consultationRepository = new Lazy<IRepository<Consultation>>(() => new Repository<Consultation>(context));
            _positionRepository = new Lazy<IRepository<Position>>(() => new Repository<Position>(context));
            _bloodTypesRepository = new Lazy<IRepository<BloodType>>(() => new Repository<BloodType>(context));
            _chatRepository = new Lazy<IChatRepository>(() => new ChatRepository(context));
            _messageRepository = new Lazy<IRepository<Message>>(() => new Repository<Message>(context));
            _doctorRepository = new Lazy<IDoctorUserRepository>(() => new DoctorUserRepository(context));
            _patientRepository = new Lazy<IPatientUserRepository>(() => new PatientUserRepository(context));
            _receptRepository = new Lazy<IRepository<Recept>>(() => new Repository<Recept>(context));
            _receptByMedicamentRepository = new Lazy<IRepository<ReceptByMedicament>>(() => new Repository<ReceptByMedicament>(context));
            _adminUserRepository = new Lazy<IRepository<AdminUser>>(() => new Repository<AdminUser>(context));
        }

        public async Task SaveChangesAsync(){
            await _context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync() {
            var result = await _context.Database.BeginTransactionAsync();
            return result;
        }

        public async Task CommitTransactionsAsync() {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task RollbackTransationsAsync() {
            await _context.Database.RollbackTransactionAsync();
        }

        #region Disposable
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing) {
            if (_disposed)
                return;

            if (disposing)
                _context.Dispose();

            _disposed = true;
        }

        ~UnitOfWork() {
            Dispose(false);
        }
        #endregion
    }
}
