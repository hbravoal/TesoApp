using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TesoApp.Common.Entities;
using TesoApp.Core.Contracts.Repository;
using TesoApp.Core.DataContext;

namespace TesoApp.Core.Repository
{
    public class GenericRepository<T>: IGenericRepository<T> where T: class, IEntity
    {
        private readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        #region Regular Members

        public IQueryable<T> GetAll()
        {
            return this.context.Set<T>().AsNoTracking();
        }

        public IList<T> GetAllMatched(Expression<Func<T, bool>> match)
        {
            return this.context.Set<T>().Where(match).ToList();
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = GetAll();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }
            return queryable;
        }
        public IQueryable<T> GetByIdAndIncluding(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = (context.Set<T>().AsNoTracking().Where(c => c.Id == id));
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }
            return queryable;
        }
        public T GetById(int id)
        {
            return this.context.Set<T>()
                .AsNoTracking().FirstOrDefault(e => e.Id == id);
        }
        public T Find(Expression<Func<T, bool>> match)
        {
            return this.context.Set<T>()
                    .AsNoTracking().SingleOrDefault(match);

        }

        public IList<T> GetAllPaged(int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = this.context.Set<T>().Count();
            return this.context.Set<T>().Skip(pageSize * pageIndex).Take(pageSize).ToList();
        }

        public int Count()
        {
            return this.context.Set<T>().Count();
        }
        public bool Create(T entity, bool saveChanges = false)
        {
            var rtn = this.context.Set<T>().Add(entity);
            if (saveChanges)
            {
                this.context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id, bool saveChanges = false)
        {
            var item = GetById(id);
            this.context.Set<T>().Remove(item);
            if (saveChanges)
            {
                try
                {
                    this.context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
            return false;
        }

        public bool Delete(T entity, bool saveChanges = false)
        {
            this.context.Set<T>().Attach(entity);
            this.context.Set<T>().Remove(entity);
            if (saveChanges)
            {
                try
                {
                    this.context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
            return false;
        }

        public bool Update(T entity, bool saveChanges = false)
        {
            var entry = context.Set<T>().Update(entity);
            entry.State = EntityState.Modified;
            if (saveChanges)
            {
                try
                {
                    this.context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
            return false;
        }

        #endregion


        public async Task<T> GetByIdAsync(int id)
        {
            return await this.context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await this.context.Set<T>().ToListAsync();
        }

        public async Task<IList<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await this.context.Set<T>().Where(match).ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await this.context.Set<T>().FindAsync(id);

        }
        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await this.context.Set<T>().SingleOrDefaultAsync(match);
        }

        public async Task<int> CountAsync()
        {
            return await this.context.Set<T>().CountAsync();
        }

        public async Task<bool> CreateAsync(T entity, bool saveChanges = false)
        {
            var rtn = await this.context.Set<T>().AddAsync(entity);
            if (saveChanges)
            {
                return await SaveAllAsync();

            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id, bool saveChanges = false)
        {
            this.context.Set<T>().Remove(GetById(id));
            if (saveChanges)
            {
                try
                {
                    await this.context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
            return false;
        }


        public async Task<bool> DeleteAsync(T entity, bool saveChanges = false)
        {
            this.context.Set<T>().Remove(entity);
            if (saveChanges)
            {
                try
                {
                    await this.context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
            return false;
        }


        public async Task<bool> UpdateAsync(T entity, bool saveChanges = false)
        {
            this.context.Set<T>().Update(entity);

            if (saveChanges)
            {
                await SaveAllAsync();
            }
            return false;
        }


        public async Task<bool> CreateAsync(T entity)
        {
            await this.context.Set<T>().AddAsync(entity);

            return await SaveAllAsync();


        }

        public async Task<bool> UpdateAsync(T entity)
        {
            this.context.Set<T>().Update(entity);

            return await SaveAllAsync();


        }

        public async Task DeleteAsync(T entity)
        {
            this.context.Set<T>().Remove(entity);
            await SaveAllAsync();
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await this.context.Set<T>().AnyAsync(e => e.Id == id);

        }

        public async Task<bool> SaveAllAsync()
        {
            try
            {
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IList<T>> GetByAllIdAsync(int id)
        {
            return (await this.context.Set<T>()
                .AsNoTracking().Where(c => c.Id == id).ToListAsync());
        }
    }
}
