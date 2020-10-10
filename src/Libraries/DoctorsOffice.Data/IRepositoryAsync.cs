using DoctorsOffice.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DoctorsOffice.Data
{
    public interface IRepositoryAsync<TEntity> : IDisposable where TEntity : ModelBase
    {
        Task<TEntity> AddAsync(TEntity obj);
        Task<int> AddAsync(IEnumerable<TEntity> entities);

        Task<TEntity> GetByIdAsync(object id);
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<int> UpdateAsync(TEntity obj);
        Task<int> UpdateAsync(IEnumerable<TEntity> entities);

        Task RemoveAsync(TEntity entity);

        IQueryable<TEntity> Table { get; }
    }
}
