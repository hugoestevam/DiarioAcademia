using System;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Aplicacao
{
    public interface IService<T> where T : class
    {
        void Add(T dto);

        void Update(T dto);

        void Delete(Guid id);

        T GetById(Guid id);

        IEnumerable<T> GetAll();
    }
}
