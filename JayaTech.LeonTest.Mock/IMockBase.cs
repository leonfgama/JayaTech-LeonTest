using System;
using System.Collections.Generic;

namespace JayaTech.LeonTest.Mock
{
    public interface IMockBase<TEntity>
    {
        TEntity GetOne();
        TEntity GetOneRandom();
        IEnumerable<TEntity> GetManyRandom(int length);
    }
}
