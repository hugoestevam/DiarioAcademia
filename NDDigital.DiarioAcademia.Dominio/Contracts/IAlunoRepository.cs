using NDDigital.DiarioAcademia.Dominio.Entities;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Dominio.Contracts
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        IList<Aluno> GetAllByTurmaId(int turmaId);
    }
}