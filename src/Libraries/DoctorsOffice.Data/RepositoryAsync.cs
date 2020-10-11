using DoctorsOffice.Core.Models.Base;
using DoctorsOffice.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DoctorsOffice.Data
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : ModelBase
    {
        private readonly DoctorsOfficeContext _context;
        private readonly DbSet<TEntity> _set;

        public RepositoryAsync(DoctorsOfficeContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity obj)
        {
            EntityEntry<TEntity> added = await _set.AddAsync(obj);
            await CommitAsync();
            return added.Entity;
        }

        public async Task<int> AddAsync(IEnumerable<TEntity> entities)
        {
            await _set.AddRangeAsync(entities);
            return await CommitAsync();
        }

        public Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                return Task.FromResult(Table);

            return Task.FromResult(Table.Where(predicate));
        }

        public virtual async Task<int> UpdateAsync(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            return await CommitAsync();
        }

        public virtual async Task<int> UpdateAsync(IEnumerable<TEntity> entities)
        {
            _set.UpdateRange(entities);
            return await CommitAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            _set.Remove(entity);
            await CommitAsync();
        }

        private async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual IQueryable<TEntity> Table => _set;

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
