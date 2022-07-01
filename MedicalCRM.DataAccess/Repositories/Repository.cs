using MedicalCRM.DataAccess.Contexts;
using MedicalCRM.DataAccess.Entities.Abstract;
using MedicalCRM.DataAccess.Exceptions;
using MedicalCRM.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Repositories {
    public class Repository<TEntity>: IRepository<TEntity> where TEntity: class, IEntity  {
        //private DbSet<TEntity> _entities { get; set; }
        private ApplicationDbContext _context;
        public IQueryable<TEntity> All { get; set; }

        public Repository(ApplicationDbContext context) {
            _context = context;
            All = context.Set<TEntity>().AsQueryable();
        }

        public async virtual Task<List<TEntity>> GetAllAsync() {
            return await All.ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id) {
            return await All.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<EntityEntry> DeleteByIdAsync(int id) {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                throw new BaseException("Такой объект не найден");
            var result = _context.Set<TEntity>().Remove(entity);
            return result;
        }

        public async Task DeleteByIds(IEnumerable<int> ids) {
            var entity = await All.Where(i => ids.Contains(i.Id)).ToListAsync();
            _context.Set<TEntity>().RemoveRange(entity);
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity) {
            var result = await _context.Set<TEntity>().AddAsync(entity);
            return result.Entity;
        }

        public virtual async Task InsertAsync(IEnumerable<TEntity> entities) {
            await _context.Set<TEntity>().AddRangeAsync(entities.ToArray());
        }

        public TEntity Update(TEntity entity) {
            _context.Entry(entity).State = EntityState.Modified;
            var result = _context.Set<TEntity>().Update(entity);
            return result.Entity;
        }

        public void Update(IEnumerable<TEntity> entities) {
            _context.Set<TEntity>().UpdateRange(entities);
        }
    }
}
