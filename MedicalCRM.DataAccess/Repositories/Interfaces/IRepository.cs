using MedicalCRM.DataAccess.Entities.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MedicalCRM.DataAccess.Repositories.Interfaces {
    public interface IRepository<TEntity> where TEntity: class, IEntity {
        IQueryable<TEntity> All { get; set; }
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task<EntityEntry> DeleteByIdAsync(int id);
        Task DeleteByIds(IEnumerable<int> ids);
        Task<TEntity> InsertAsync(TEntity entity);
        TEntity Update(TEntity entity);
        Task InsertAsync(IEnumerable<TEntity> entities);
        void Update(IEnumerable<TEntity> entities);
    }
}
