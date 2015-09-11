using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Aplicacao.Services
{
    public interface IService<T>
    {
        void Add(T obj);

        void Update(T obj);

        void Delete(int id);

        T GetById(int id);

        IList<T> GetAll();
    }
}