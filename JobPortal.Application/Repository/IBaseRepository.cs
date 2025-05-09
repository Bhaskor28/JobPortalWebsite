using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        public IQueryable<T> Table { get; }
        Task<IEnumerable<T>> GetAllAsync();
    }
}
