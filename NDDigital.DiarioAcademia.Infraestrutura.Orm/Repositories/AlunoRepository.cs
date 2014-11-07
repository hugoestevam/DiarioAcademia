using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Uniplac.Sindicontrata.Infraestrutura.AcessoDadosRepositories
{
    public class AlunoRepository : RepositoryBase<Aluno>, IAlunoRepository
    {
        public AlunoRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<Aluno> GetAllByTurma(int ano)
        {
            return 
                GetQueryable()
                .Where(x => x.Turma.Ano == ano)
                .ToList();            
        }        
    }
}