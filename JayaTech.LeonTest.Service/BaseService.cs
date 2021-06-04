using JayaTech.LeonTest.Domain.Entities;
using JayaTech.LeonTest.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        public IBaseRepository<TEntity> BaseRepository { get; set; }
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            this.BaseRepository = baseRepository;
        }

        public async Task<TEntity> InsertAsync(TEntity obj)
        {
            return await this.BaseRepository.InsertAsync(obj);
        }

        public async Task<TEntity> UpdateAsync(TEntity obj)
        {
            return await this.BaseRepository.UpdateAsync(obj);
        }

        public async Task DeleteAsync(TEntity obj)
        {
            await this.DeleteAsync(obj);
        }

        public async Task DeleteAsync(int id)
        {
            await this.DeleteAsync(id);
        }

        public async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await this.SearchAsync(expression);
        }

        public async Task<TEntity> SearchFirstAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await this.SearchFirstAsync(expression);
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await this.GetAsync(id);
        }
    }
}
