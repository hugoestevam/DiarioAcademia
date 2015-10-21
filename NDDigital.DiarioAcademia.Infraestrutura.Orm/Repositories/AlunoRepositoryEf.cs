using Infrastructure.DAO.ORM.Common.Base;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories
{
    public class AlunoRepositoryEF : RepositoryBaseEF<Aluno>, IAlunoRepository
    {
        public AlunoRepositoryEF(EntityFrameworkFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IList<Aluno> GetAllByTurma(int ano)
        {
            return GetQueryable()
                .Include(x => x.Turma)
                .Include(x => x.Presencas)
                .Where(x => x.Turma.Ano == ano)
                .ToList();
        }

        public override IList<Aluno> GetAll()
        {
            return GetQueryable()
                .Include(x => x.Turma)
                .Include(x => x.Presencas)
                .ToList();
        }

        public override Aluno GetById(int id)
        {
            var aluno = GetQueryable()
               .Include(x => x.Turma)
               .Include(x => x.Presencas)
               .FirstOrDefault(x => x.Id == id);

            return aluno;
        }

        public IList<Aluno> GetAllByTurmaId(int id)
        {
            return GetQueryable()
                    .Include(x => x.Turma)
                    .Include(x => x.Presencas)
                    .Where(x => x.Turma.Id == id)
                    .ToList();
        }


        public IQueryable<Aluno> GetAlunos()
        {
            return GetQueryable();
        }
    }
}
