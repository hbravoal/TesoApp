namespace TesoApp.Core.Contracts.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IGenericRepository<T> where T: class
    {
        IQueryable<T> GetAll();
        Task<IList<T>> GetAllAsync();

        Task<bool> CreateAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<bool> ExistAsync(int id);

        IList<T> GetAllMatched(Expression<Func<T, bool>> match);

        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetByIdAndIncluding(int id, params Expression<Func<T, object>>[] includeProperties);
        T GetById(int id);

        T Find(Expression<Func<T, bool>> match);



        IList<T> GetAllPaged(int pageIndex, int pageSize, out int totalCount);

        int Count();

        bool Create(T entity, bool saveChanges = false);

        bool Delete(int id, bool saveChanges = false);

        bool Delete(T entity, bool saveChanges = false);

        bool Update(T entity, bool saveChanges = false);

        Task<IList<T>> FindAllAsync(Expression<Func<T, bool>> match);
        Task<T> GetByIdAsync(int id);
        Task<IList<T>> GetByAllIdAsync(int id);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        Task<int> CountAsync();
        Task<bool> DeleteAsync(int id, bool saveChanges = false);
        Task<bool> DeleteAsync(T entity, bool saveChanges = false);
        Task<bool> UpdateAsync(T entity, bool saveChanges = false);


    }
}