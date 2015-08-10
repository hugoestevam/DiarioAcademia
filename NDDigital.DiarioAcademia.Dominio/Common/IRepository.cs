using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NDDigital.DiarioAcademia.Dominio
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        T GetById(int id);

        T GetByIdIncluding(int id, params Expression<Func<T, object>>[] includeProperties);

        IList<T> GetAll();

        IList<T> GetMany(Expression<Func<T, bool>> where);

        IList<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
    }
}