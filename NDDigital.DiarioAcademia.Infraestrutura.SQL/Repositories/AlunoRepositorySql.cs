using Infraestrutura.DAO.SQL.Common;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.SQL.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace NDDigital.DiarioAcademia.Infraestrutura.SQL.Repositories
{
    public class AlunoRepositorySql : RepositoryBaseADO, IAlunoRepository
    {
        #region Querys

        public const string SqlInsert =
            @"INSERT INTO TBAluno
                  (Endereco_Cep
                  ,Endereco_Bairro
                  ,Endereco_Localidade
                  ,Endereco_Uf
                  ,Nome
                  ,Turma_Id)
            VALUES
                  ({0}Endereco_Cep,
                   {0}Endereco_Bairro,
                   {0}Endereco_Localidade,
                   {0}Endereco_Uf,
                   {0}Nome,
                   {0}Turma_Id)";

        public const string SqlUpdate =
            @"UPDATE TBAluno SET
                    Endereco_Cep = {0}Endereco_Cep
                   ,Endereco_Bairro = {0}Endereco_Bairro
                   ,Endereco_Localidade = {0}Endereco_Localidade
                   ,Endereco_Uf = {0}Endereco_Uf
                   ,Nome = {0}Nome
                   ,Turma_Id = {0}Turma_Id
              WHERE Id = {0}id";

        public const string SqlDelete =
            @"DELETE FROM TBAluno WHERE Id = {0}id";

        public const string SqlSelect =
            @"SELECT A.Id,A.Endereco_Cep,A.Endereco_Bairro
                  ,A.Endereco_Localidade,A.Endereco_Uf
                  ,A.Nome,A.Turma_Id
                  ,T.Ano
              FROM TBAluno AS A
              INNER JOIN TBTurma AS T ON T.Id = A.Turma_Id";

        public const string SqlSelectById =
            @"SELECT A.Id,A.Endereco_Cep,A.Endereco_Bairro
                  ,A.Endereco_Localidade,A.Endereco_Uf
                  ,A.Nome,A.Turma_Id
                  ,T.Ano
              FROM TBAluno AS A
              INNER JOIN TBTurma AS T ON T.Id = A.Turma_Id
              WHERE A.Id = {0}id";

        //public const string SqlInsertPresenca =
        //    @"INSERT INTO TBPresenca (StatusPresenca, Aula_Id, Aluno_Id)
        //      VALUES ({0}StatusPresenca, {0}Aula_Id, {0}Aluno_Id)";

        //public const string SqlSelectPresenca =
        //    @"SELECT P.Id,P.StatusPresenca,P.Aula_Id,P.Aluno_Id,
        //          AL.Data, AL.ChamadaRealizada, AL.Turma_Id,
        //          A.Nome, A.Endereco_Cep, A.Endereco_Bairro, A.Endereco_Localidade, A.Endereco_Uf,
        //          T.Ano
        //      FROM TBPresenca AS P
        //          INNER JOIN TBAula AS AL ON AL.Id = P.Aula_Id
        //          INNER JOIN TBAluno AS A ON A.Id = P.Aluno_Id
        //          INNER JOIN TBTurma AS T ON T.Id = AL.Turma_Id
        //      WHERE Aluno_Id = {0}Id_Aluno and Aula_Id = {0}Id_Aula";

        public const string SqlUpdatePresenca =
            @"UPDATE TBPresenca SET StatusPresenca = {0}StatusPresenca,
                                    Aula_Id = {0}Aula_Id,
                                    Aluno_Id = {0}Aluno_Id
              WHERE Id = {0}Id";

        public const string SqlSelectPresencasByAluno =
            @"SELECT P.Id,P.StatusPresenca,P.Aula_Id,P.Aluno_Id,
	                 AL.Data, AL.ChamadaRealizada, AL.Turma_Id,
	                 A.Nome, A.Endereco_Cep, A.Endereco_Bairro, A.Endereco_Localidade, A.Endereco_Uf,
	                 T.Ano
              FROM TBPresenca AS P
                  INNER JOIN TBAula AS AL ON AL.Id = P.Aula_Id
                  INNER JOIN TBAluno AS A ON A.Id = P.Aluno_Id
                  INNER JOIN TBTurma AS T ON T.Id = AL.Turma_Id
              WHERE P.Aluno_Id = {0}Id_Aluno";

        private PresencaRepositorySql _repoPresenca;

        #endregion Querys

        public AlunoRepositorySql(AdoNetFactory factory)
            : base(factory)
        {
            _repoPresenca = new PresencaRepositorySql(factory);
        }

        public Aluno Add(Aluno entity)
        {
            Insert(SqlInsert, Take(entity));

            return entity;
        }

        public void Delete(int id)
        {
            var alunoRemovido = GetById(id);
            Delete(SqlDelete, Take(alunoRemovido));
        }

        public void Delete(Aluno entity)
        {
            Delete(SqlDelete, Take(entity));
        }

        public IList<Aluno> GetAll()
        {
            IList<Aluno> listaAlunos = null;

            listaAlunos = GetAll(SqlSelect, Make);

            foreach (var aluno in listaAlunos)
            {
                aluno.Presencas = _repoPresenca.GetAllByAluno(aluno.Id);
            }

            return listaAlunos;
        }

        public Aluno GetById(int id)
        {
            Aluno aluno = null;

            var parms = new object[] { "id", id };

            aluno = Get(SqlSelectById, Make, parms);

            var parms_ = new object[] { "Id_Aluno", aluno.Id };

            aluno.Presencas = GetAll(SqlSelectPresencasByAluno, MakePresenca, parms_);

            return aluno;
        }

        public void Update(Aluno entity)
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

        private static Aluno Make(IDataReader reader)
        {
            Aluno aluno = new Aluno();
            aluno.Id = Convert.ToInt32(reader["Id"]);
            aluno.Nome = Convert.ToString(reader["Nome"]);
            aluno.Turma = new Turma
            {
                Id = Convert.ToInt32(reader["Turma_Id"]),
                Ano = Convert.ToInt32(reader["Ano"])
            };
            aluno.Endereco = new Endereco
            {
                Cep = Convert.ToString(reader["Endereco_Cep"]),
                Localidade = Convert.ToString(reader["Endereco_Localidade"]),
                Bairro = Convert.ToString(reader["Endereco_Bairro"]),
                Uf = Convert.ToString(reader["Endereco_Uf"])
            };

            return aluno;
        }

        private static Presenca MakePresenca(IDataReader reader)
        {
            Presenca presenca = new Presenca();

            presenca.Id = Convert.ToInt32(reader["Id"]);
            presenca.Aluno = new Aluno
            {
                Id = Convert.ToInt32(reader["Aluno_Id"]),
                Nome = Convert.ToString(reader["Nome"]),
                Turma = new Turma
                {
                    Id = Convert.ToInt32(reader["Turma_Id"]),
                    Ano = Convert.ToInt32(reader["Ano"]),
                },
                Endereco = new Endereco
                {
                    Cep = Convert.ToString(reader["Endereco_Cep"]),
                    Localidade = Convert.ToString(reader["Endereco_Localidade"]),
                    Bairro = Convert.ToString(reader["Endereco_Bairro"]),
                    Uf = Convert.ToString(reader["Endereco_Uf"])
                }
            };
            presenca.Aula = new Aula
            {
                Id = Convert.ToInt32(reader["Aula_Id"]),
                Data = Convert.ToDateTime(reader["Data"]),
                ChamadaRealizada = Convert.ToBoolean(reader["ChamadaRealizada"]),
                Turma = new Turma
                {
                    Id = Convert.ToInt32(reader["Turma_Id"]),
                    Ano = Convert.ToInt32(reader["Ano"]),
                },
            };
            presenca.StatusPresenca = Convert.ToString(reader["StatusPresenca"]);

            return presenca;
        }

        private static object[] Take(Aluno aluno)
        {
            return new object[]
            {
                "Id", aluno.Id,
                "Nome", aluno.Nome,
                "Turma_Id", aluno.Turma.Id,
                "Endereco_Cep", aluno.Endereco.Cep,
                "Endereco_Localidade", aluno.Endereco.Localidade,
                "Endereco_Bairro", aluno.Endereco.Bairro,
                "Endereco_Uf", aluno.Endereco.Uf
            };
        }

        private static object[] TakePresenca(Presenca presenca)
        {
            return new object[]
            {
                "Id", presenca.Id,
                "Aluno_Id", presenca.Aluno.Id,
                "Nome", presenca.Aluno.Nome,
                "Aula_Id", presenca.Aula.Id,
                "StatusPresenca", presenca.StatusPresenca,
            };
        }

        public Aluno GetByIdIncluding(int id, params Expression<Func<Aluno, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IList<Aluno> GetMany(Expression<Func<Aluno, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IList<Aluno> GetAllIncluding(params Expression<Func<Aluno, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IList<Aluno> GetAllByTurmaId(int turmaId)
        {
            return GetAll()
                .Where(a => a.Turma.Id == turmaId)
                .ToList();
        }
    }
}