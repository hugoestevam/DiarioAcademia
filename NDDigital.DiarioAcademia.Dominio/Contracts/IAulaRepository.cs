using NDDigital.DiarioAcademia.Dominio.Entities;
using System;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Dominio.Contracts
{
    public interface IAulaRepository : IRepository<Aula>
    {
        Aula GetByData(DateTime data);

        IList<Aula> GetAllByTurmaId(int id);
    }
}