using JobPortal.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public IQueryable<T> Table { get; }
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
        IQueryable<T> GetQueryable();
        Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
    }
}
