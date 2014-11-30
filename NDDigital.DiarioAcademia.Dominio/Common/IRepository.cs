using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NDDigital.DiarioAcademia.Dominio
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        T GetById(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        IEnumerable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
    }
}