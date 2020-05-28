using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.AppContext;
using Core.IRepository;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Repository
{
    public class Methods<T> : IMethods<T> where T : BaseEntity
    {
        private readonly ApplicationContext _context;
        protected readonly DbSet<T> Set;

        public Methods(ApplicationContext context)
        {
            this._context = context;
            Set = context.Set<T>();
        }

        public async Task<T> Delete(int id)
        {
            var model = await GetByIdAsync(id);
            _context.Remove(model);
            await SaveAsync();
            return model;
            
        }

        public async Task<List<T>> GetAllAsync()
        {
            var models = await _context.Set<T>().ToListAsync();
            return models;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var model = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            return model;
        }   

        public async Task<T> PostAsync(T model)
        {
            var newModel = await _context.Set<T>().AddAsync(model);
            await SaveAsync();

            return await GetByIdAsync(newModel.Entity.Id);
        }

        public async Task Put(T model)
        {
            try
            {
                EntityEntry entity = _context.Entry(model);
                entity.State = EntityState.Modified;
                await SaveAsync();

            }catch(Exception ex)
            {
                ex.Message.ToString();
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public virtual T Find(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = Set.AsQueryable();

            foreach (Expression<Func<T, object>> include in includes)
            {
                queryable = queryable.Include(include);
            }

            return queryable.FirstOrDefault(condition);

        }
    }
}
