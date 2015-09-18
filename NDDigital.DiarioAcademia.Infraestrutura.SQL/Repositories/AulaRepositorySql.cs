using Infraestrutura.DAO.SQL.Common;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.SQL.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace NDDigital.DiarioAcademia.Infraestrutura.SQL.Repositories
{
    public class AulaRepositorySql : RepositoryBaseADO, IAulaRepository
    {
        #region Querys

        public const string SqlInsert = @"INSERT INTO TBAula
            (Data, ChamadaRealizada, Turma_Id) VALUES
            ({0}Data, {0}ChamadaRealizada, {0}Turma_Id)";

        public const string SqlUpdate = @"UPDATE TBAula SET
            Data = {0}Data,
            ChamadaRealizada = {0}ChamadaRealizada,
            Turma_Id = {0}Turma_Id
            WHERE Id = {0}Id";

        public const string SqlDelete = @"DELETE FROM TBAula
            WHERE Id = {0}Id";

        public const string SqlSelect =
            @"SELECT A.Id
                  ,A.ChamadaRealizada
                  ,A.Data
                  ,A.Turma_Id
	              ,T.Id
	              ,T.Ano AS AnoTurma
              FROM TBAula AS A
              INNER JOIN TBTurma AS T ON A.Turma_Id = T.Id";

        public const string SqlSelectById =
            @"SELECT A.Id
                  ,A.ChamadaRealizada
                  ,A.Data
                  ,A.Turma_Id
	              ,T.Id
	              ,T.Ano AS AnoTurma
              FROM TBAula AS A
              INNER JOIN TBTurma AS T ON A.Turma_Id = T.Id
              WHERE A.Id = {0}Id";

        public const string SqlSelectPresencasByAula =
            @"SELECT P.Id, P.StatusPresenca, A.Nome as NomeAluno,
                     P.Aula_Id, P.Aluno_Id, AL.Data
                FROM TBPresenca AS P
	                INNER JOIN TBAula AS AL ON AL.Id = P.Aula_Id
                    INNER JOIN TBAluno AS A ON A.Id = P.Aluno_Id
              WHERE P.Aula_Id = {0}Id_Aula";

        #endregion Querys

        public AulaRepositorySql(AdoNetFactory factory) : base(factory)
        {
        }

        public Aula Add(Aula entity)
        {
            try
            {
                Insert(SqlInsert, Take(entity));
            }
            catch (Exception te)
            {
                throw new Exception("Erro ao tentar adicionar uma Aula!" + te.Message);
            }
            return entity;
        }

        public void Delete(int id)
        {
            try
            {
                var aulaRemovida = GetById(id);
                Delete(SqlDelete, Take(aulaRemovida));
            }
            catch (Exception te)
            {
                throw new Exception("Erro ao tentar deletar uma Aula!" + te.Message);
            }
        }

        public void Delete(Aula entity)
        {
            try
            {
                var aulaRemovida = GetById(entity.Id);
                Delete(SqlDelete, Take(aulaRemovida));
            }
            catch (Exception te)
            {
                throw new Exception("Erro ao tentar deletar uma Aula!" + te.Message);
            }
        }

        public IList<Aula> GetAll()
        {
            IList<Aula> listAulas = null;

            try
            {
                listAulas = GetAll(SqlSelect, Make);

                foreach (var aula in listAulas)
                {
                    var parms = new object[] { "Id_Aula", aula.Id };

                    aula.Presencas = GetAll(SqlSelectPresencasByAula, MakePresenca, parms);
                }
            }
            catch (Exception te)
            {
                throw new Exception("Erro ao tentar listar todas as Aulas!" + te.Message);
            }

            return listAulas;
        }

        public IList<Aula> GetAllByTurmaId()
        {
            try
            {
                return GetAll();
            }
            catch (Exception te)
            {
                throw new Exception("Erro ao tentar listar todas as Aulas por determinada turma!" + te.Message);
            }
        }

        public Aula GetById(int id)
        {
            Aula aula = null;
            try
            {
                var parms = new object[] { "Id", id };

                aula = Get(SqlSelectById, Make, parms);

                var parmsPresencas = new object[] { "Id_Aula", aula.Id };

                aula.Presencas = GetAll(SqlSelectPresencasByAula, MakePresenca, parmsPresencas);
            }
            catch (Exception te)
            {
                throw new Exception(te.Message);
            }

            return aula;
        }

        public void Update(Aula entity)
        {
            try
            {
                Update(SqlUpdate, Take(entity));
            }
            catch (Exception te)
            {
                throw new Exception("Erro ao tentar editar uma Aula!" + te.Message);
            }
        }

        private Aula Make(IDataReader reader)
        {
            Aula aula = new Aula();

            aula.Id = Convert.ToInt32(reader["Id"]);
            aula.Data = Convert.ToDateTime(reader["Data"]);
            aula.ChamadaRealizada = Convert.ToBoolean(reader["ChamadaRealizada"]);
            aula.Turma.Id = Convert.ToInt32(reader["Turma_Id"]);
            aula.Turma.Ano = Convert.ToInt32(reader["AnoTurma"]);

            return aula;
        }

        private static object[] Take(Aula aula)
        {
            return new object[]
            {
                "Id", aula.Id,
                "Data", aula.Data,
                "ChamadaRealizada", aula.ChamadaRealizada,
                "Turma_Id", aula.Turma.Id,
                "AnoTurma", aula.Turma.Ano
            };
        }

        private static object[] TakePresenca(Presenca presenca)
        {
            return new object[]
            {
                "Id", presenca.Id,
                "Aluno_Id", presenca.Aluno.Id,
                "NomeAluno", presenca.Aluno.Nome,
                "Aula_Id", presenca.Aula.Id,
                "StatusPresenca", presenca.StatusPresenca,
            };
        }

        private static Presenca MakePresenca(IDataReader reader)
        {
            Presenca presenca = new Presenca();

            presenca.Id = Convert.ToInt32(reader["Id"]);
            presenca.Aluno.Id = Convert.ToInt32(reader["Aluno_Id"]);
            presenca.Aluno.Nome = Convert.ToString(reader["NomeAluno"]);
            presenca.Aula.Id = Convert.ToInt32(reader["Aula_Id"]);
            presenca.StatusPresenca = Convert.ToString(reader["StatusPresenca"]);

            return presenca;
        }

        #region Métodos Não utilizados

        public IList<Aula> GetAllIncluding(params Expression<Func<Aula, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Aula GetByData(DateTime data)
        {
            throw new NotImplementedException();
        }

        public Aula GetByIdIncluding(int id, params Expression<Func<Aula, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IList<Aula> GetMany(Expression<Func<Aula, bool>> where)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}