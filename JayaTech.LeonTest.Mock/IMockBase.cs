using System;
using System.Collections.Generic;

namespace JayaTech.LeonTest.Mock
{
    public interface ImockBase<TEntity>
    {
        TEntity GetOne();
        TEntity GetOneRandom();
        IEnumerable<TEntity> GetManyRandom(int length);
    }
}
