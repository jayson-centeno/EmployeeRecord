using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecord.Repository
{
    public interface IGenericRepository
    {
        T Add<T>(T t) where T : class;
        Task<T> AddAsync<T>(T t) where T : class;
        int Count<T>() where T : class;
        Task<int> CountAsync<T>() where T : class;
        void Delete<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;
        void Dispose();
        T Find<T>(Expression<Func<T, bool>> match) where T : class;
        ICollection<T> FindAll<T>(Expression<Func<T, bool>> match) where T : class;
        Task<ICollection<T>> FindAllAsync<T>(Expression<Func<T, bool>> match) where T : class;
        Task<T> FindAsync<T>(Expression<Func<T, bool>> match) where T : class;
        IQueryable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<ICollection<T>> FindByAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        T Get<T>(int id) where T : class;
        IQueryable<T> GetAll<T>() where T : class;
        Task<ICollection<T>> GetAllAsync<T>() where T : class;
        IQueryable<T> GetAllIncluding<T>(params Expression<Func<T, object>>[] includeProperties) where T : class;
        Task<T> GetAsync<T>(int id) where T : class;
        void Save();
        Task<int> SaveAsync();
        T Update<T> (T t, object key) where T : class;
        Task<T> UpdateAsync<T>(T t, object key) where T : class;
    }
}
