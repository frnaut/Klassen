using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IMethods<T> where T: BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> PostAsync(T model);
        Task Put(T model);
        Task SaveAsync();
        Task<T> Delete(int id);
         abstract T Find(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes);


    }
}
