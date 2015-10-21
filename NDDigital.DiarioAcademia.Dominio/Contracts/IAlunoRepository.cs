using NDDigital.DiarioAcademia.Dominio.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NDDigital.DiarioAcademia.Dominio.Contracts
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        IList<Aluno> GetAllByTurmaId(int turmaId);

        IQueryable<Aluno> GetAlunos();
    }
}