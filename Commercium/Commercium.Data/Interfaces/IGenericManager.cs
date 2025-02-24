using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Data.Interfaces
{
    public interface IGenericManager<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression, params Func<IQueryable<T>, IQueryable<T>>[] includes);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null,
                                         Func<IQueryable<T>, IOrderedQueryable<T>>? values = null,
                                         params Func<IQueryable<T>, IQueryable<T>>[] includes);

        Task<T> FindAsync(Expression<Func<T, bool>> expression);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);

        Task<T> AddAsync(T item);
        Task AddRangeAsync(IEnumerable<T> items);
        void Update(T item);
        void Delete(T item);
        Task DeleteRangeAsync(IEnumerable<T> items);

        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetTopAsync(int count,
                                         Expression<Func<T, bool>>? expression = null,
                                         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                         params Func<IQueryable<T>, IQueryable<T>>[] includes);
        Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<int> ids);
        Task GetByIdAsync(string followedId);
    }
    
}
