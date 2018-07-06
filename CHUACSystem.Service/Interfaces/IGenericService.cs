using CHUACSystem.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace CHUACSystem.Service.Interfaces
{
    public interface IGenericService<TEntity, TView, TBase> where TView : TBase
    {
        TView GetById(long id);
        IEnumerable<TView> GetAll();
        IEnumerable<TView> Find(Func<TEntity, bool> predicate);
        ReturnVM Create(TBase model);
        ReturnVM Update(TView model);
        ReturnVM Delete(long id);
    }
}
