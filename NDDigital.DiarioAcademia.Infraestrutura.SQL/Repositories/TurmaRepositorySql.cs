using NDDigital.DiarioAcademia.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data;
using NDDigital.DiarioAcademia.Dominio.Exceptions;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Dominio.Contracts;

namespace NDDigital.DiarioAcademia.Infraestrutura.SQL.Repositories
{
    public class TurmaRepositorySql : ITurmaRepository
    {
        #region Querys

        public const string SqlInsert =
            "INSERT INTO TBTurma (Ano) " +
                         "VALUES ({0}Ano)";

        public const string SqlUpdate =
         "UPDATE TBTurma SET Ano = {0}Ano " +
                      "WHERE Id = {0}Id";

        public const string SqlDelete =
         "DELETE FROM TBTurma " +
                       "WHERE Id = {0}Id";

        public const string SqlSelect =
         "SELECT * FROM TBTurma";

        public const string SqlSelectbId =
        "SELECT * FROM TBTurma WHERE Id = {0}Id";

        #endregion Querys

        public Turma Add(Turma turma)
        {
            try
            {
                Db.Insert(SqlInsert, Take(turma));
            }
            catch (TurmaException te)
            {
                throw new TurmaException("Erro ao tentar adicionar uma Turma!" + te.Message);
            }
            return turma;
        }

        public void Delete(int id)
        {
            try
            {
                var turmaRemovida = GetById(id);
                Db.Delete(SqlDelete, Take(turmaRemovida));
            }
            catch (TurmaException te)
            {
                throw new TurmaException("Erro ao tentar deletar uma Turma!" + te.Message);
            }
        }

        public void Delete(Turma entity)
        {
            try
            {
                var turmaRemovida = GetById(entity.Id);
                Db.Delete(SqlDelete, Take(turmaRemovida));
            }
            catch (TurmaException te)
            {
                throw new TurmaException("Erro ao tentar deletar uma Turma!" + te.Message);
            }
        }

        public IEnumerable<Turma> GetAll()
        {
            try
            {
                return Db.GetAll<Turma>(SqlSelect, Make);
            }
            catch (TurmaException te)
            {
                throw new TurmaException("Erro ao tentar listar todas as Turmas!" + te.Message);
            }
        }

        public Turma GetById(int id)
        {
            try
            {
                var parms = new object[] { "Id", id };

                return Db.Get(SqlSelectbId, Make, parms);
            }
            catch (Exception te)
            {
                return null;
                throw new TurmaException("Erro ao tentar encontrar a turma!" + te.Message);
            }
        }

        public void Update(Turma entity)
        {
            try
            {
                var turmaEditada = GetById(entity.Id);
                Db.Update(SqlUpdate, Take(turmaEditada));
            }
            catch (TurmaException te)
            {
                throw new TurmaException("Erro ao tentar editar uma Turma!" + te.Message);
            }
        }

        private static Turma Make(IDataReader reader)
        {
            Turma turma = new Turma();
            turma.Id = Convert.ToInt32(reader["Id"]);
            turma.Ano = Convert.ToInt32(reader["Ano"]);

            return turma;
        }

        private static object[] Take(Turma turma)
        {
            return new object[]
            {
                "Id", turma.Id,
                "Ano", turma.Ano
            };
        }

        public IEnumerable<Turma> GetAllIncluding(params Expression<Func<Turma, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Turma GetByIdIncluding(int id, params Expression<Func<Turma, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Turma> GetMany(Expression<Func<Turma, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
