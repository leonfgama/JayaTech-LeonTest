using JayaTech.LeonTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JayaTech.LeonTest.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Insert(TEntity obj);

        TEntity Update(TEntity obj);
        void Delete(TEntity obj);

        void Delete(int id);

        IList<TEntity> GetAll();

        TEntity Get(int id);
    }
}
