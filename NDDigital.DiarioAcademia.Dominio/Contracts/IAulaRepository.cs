using NDDigital.DiarioAcademia.Dominio.Entities;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Dominio.Contracts
{
    public interface IAulaRepository : IRepository<Aula>
    {
        IList<Aula> GetAllByTurmaId();
    }
}