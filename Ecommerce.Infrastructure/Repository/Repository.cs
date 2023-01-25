using Ecommerce.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext context;

        public Repository(DbContext context) {

            this.context = context;
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await context.Set<T>().AddRangeAsync(entities);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void SaveAsync()
        {
            context.SaveChangesAsync();
        }

        public void Update(int id, Action<T> updateAction)
        {
            var entity = context.Set<T>().Find(id);
            updateAction(entity);
        }

        public async void UpdateAsync(int id, Action<T> updateAction)
        {
            var entity = await context.Set<T>().FindAsync(id);
            updateAction(entity);
        }

        public async Task<TResult> ExistsAsync<TResult>(int id, Func<TResult> ifExist)
        {
            TResult? result = default;

            var entity = await context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                result = ifExist();
            }
            return result;
        }
        public TResult Exists<TResult>(int id, Func<TResult> ifExist)
        {
            TResult? result = default;

            var entity = context.Set<T>().Find(id);
            if (entity != null)
            {
                result = ifExist();
            }
            return result;
        }
    }
}
