using Core.Models.Base;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
    }
}
