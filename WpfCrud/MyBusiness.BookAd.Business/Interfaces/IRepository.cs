using System.Collections.Generic;

namespace MyBusiness.BookAd.Business.Interfaces
{
    public interface IRepository<T> where T : BusinessEntity
    {
        void Create(T entity);

        T Get(int id);

        void Update(T entity);

        IEnumerable<T> GetAll();

        void Delete(T entity);
    }
}
