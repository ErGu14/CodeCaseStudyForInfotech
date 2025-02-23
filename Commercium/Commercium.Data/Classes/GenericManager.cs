using Commercium.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Data.Classes
{
    public class GenericManager<T> : IGenericManager<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericManager(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // ID'ye göre tek bir nesne getirme
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Tek bir nesne getirme (dinamik filtreleme)
        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, params Func<IQueryable<T>, IQueryable<T>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            query = includes.Aggregate(query, (current, include) => include(current));
            return await query.FirstOrDefaultAsync(expression);
        }

        // Tüm nesneleri getirme
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // Tüm nesneleri getirme (dinamik filtreleme)
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null,
                                                      Func<IQueryable<T>, IOrderedQueryable<T>>? values = null,
                                                      params Func<IQueryable<T>, IQueryable<T>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            if (expression != null)
                query = query.Where(expression);

            query = includes.Aggregate(query, (current, include) => include(current));

            if (values != null)
                query = values(query);

            return await query.ToListAsync();
        }

        // Bir nesne bulma
        public async Task<T> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        // Belirli bir nesnenin olup olmadığını kontrol etme
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        // Yeni nesne ekleme
        public async Task<T> AddAsync(T item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        // Toplu nesne ekleme
        public async Task AddRangeAsync(IEnumerable<T> items)
        {
            await _dbSet.AddRangeAsync(items);
            await _context.SaveChangesAsync();
        }

        // Güncelleme işlemi
        public void Update(T item)
        {
            _dbSet.Update(item);
            _context.SaveChanges();
        }

        // Nesneyi silme
        public void Delete(T item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        // Toplu nesne silme
        public async Task DeleteRangeAsync(IEnumerable<T> items)
        {
            _dbSet.RemoveRange(items);
            await _context.SaveChangesAsync();
        }

        // Toplam nesne sayısını alma
        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        // Belirli bir filtreye göre nesne sayısını alma
        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.CountAsync(expression);
        }

        // En çok istenen nesneleri getirme (örneğin en çok beğenilen ürünler)
        public async Task<IEnumerable<T>> GetTopAsync(int count,
                                                      Expression<Func<T, bool>>? expression = null,
                                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                      params Func<IQueryable<T>, IQueryable<T>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            if (expression != null)
                query = query.Where(expression);

            query = includes.Aggregate(query, (current, include) => include(current));

            if (orderBy != null)
                query = orderBy(query);

            return await query.Take(count).ToListAsync();
        }
    }

}
