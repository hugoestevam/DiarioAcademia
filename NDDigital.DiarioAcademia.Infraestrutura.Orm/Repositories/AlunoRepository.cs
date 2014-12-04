using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories
{
    public class AlunoRepository : RepositoryBase<Aluno>, IAlunoRepository
    {
        public AlunoRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<Aluno> GetAllByTurma(int ano)
        {
            return GetQueryable()
                .Include(x => x.Turma)
                .Include(x => x.Presencas)
                .Where(x => x.Turma.Ano == ano)
                .ToList();
        }
    }
}