using System;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Aplicacao
{
    public interface IService<T> where T : class
    {
        void Add(T dto);

        void Update(T dto);

        void Delete(int id);

        T GetById(int id);

        IEnumerable<T> GetAll();
    }
}
