using JayaTech.LeonTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Insert(TEntity obj, IDbTransaction sqlTransaction = null);
        Task<TEntity> Update(TEntity obj, IDbTransaction sqlTransaction = null);
        Task Delete(TEntity obj, IDbTransaction sqlTransaction = null);
        Task Delete(int id, IDbTransaction sqlTransaction = null);
        Task<IList<TEntity>> Search(Expression<Func<TEntity, bool>> expression, IDbTransaction sqlTransaction = null);
        Task<TEntity> SearchFirst(Expression<Func<TEntity, bool>> expression, IDbTransaction sqlTransaction = null);
        Task<TEntity> Get(int id, IDbTransaction sqlTransaction = null);
    }
}
