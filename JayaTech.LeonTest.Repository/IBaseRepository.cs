using JayaTech.LeonTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> InsertAsync(TEntity obj, IDbTransaction sqlTransaction = null);
        Task<TEntity> UpdateAsync(TEntity obj, IDbTransaction sqlTransaction = null);
        void Delete(int id, IDbTransaction sqlTransaction = null);
        void Delete(TEntity obj, IDbTransaction sqlTransaction = null);
        Task DeleteAsync(TEntity obj, IDbTransaction sqlTransaction = null);
        Task DeleteAsync(int id, IDbTransaction sqlTransaction = null);
        Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> expression, IDbTransaction sqlTransaction = null);
        Task<TEntity> SearchFirstAsync(Expression<Func<TEntity, bool>> expression, IDbTransaction sqlTransaction = null);
        Task<TEntity> GetAsync(int id, IDbTransaction sqlTransaction = null);
    }
}