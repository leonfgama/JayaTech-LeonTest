using JayaTech.LeonTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.Service
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> InsertAsync(TEntity obj);
        Task<TEntity> UpdateAsync(TEntity obj);
        Task DeleteAsync(TEntity obj);
        Task DeleteAsync(int id);
        Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> SearchFirstAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetAsync(int id);
    }
}
