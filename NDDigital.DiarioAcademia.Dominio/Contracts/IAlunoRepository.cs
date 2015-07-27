using NDDigital.DiarioAcademia.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Dominio.Contracts
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        IEnumerable<Aluno> GetAllByTurma(int ano);
        IEnumerable<Aluno> GetAllByTurmaId(int id);
    }
}
