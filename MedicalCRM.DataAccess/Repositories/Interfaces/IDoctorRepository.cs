using MedicalCRM.DataAccess.Entities.UserEntities;

namespace MedicalCRM.DataAccess.Repositories.Interfaces {
    public interface IDoctorUserRepository: IRepository<DoctorUser> {
        Task<DoctorUser?> GetDoctorWithNavigationAsync(int DoctorId);
        Task<List<int>> GetDoctorIds();
        Task<(List<DoctorUser> Users, int Count)> GetFilteredPatientsQuery(UserFilterView filter);
    }
}
