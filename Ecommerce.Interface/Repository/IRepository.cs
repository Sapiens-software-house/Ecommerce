using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Interface.Repository
{
    public interface IRepository<T> where T : class // T is domain
    {
        void Add(T entity);
        Task AddAsync(T entity);
        void AddRange(IEnumerable<T> entities);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        void Save();
        void SaveAsync();
        void Update(int id, Action<T> updateAction);
        void UpdateAsync(int id, Action<T> updateAction);
        Task<TResult> ExistsAsync<TResult>(int id, Func<TResult> ifExist);
        TResult Exists<TResult>(int id, Func<TResult> ifExist);
    }
}
