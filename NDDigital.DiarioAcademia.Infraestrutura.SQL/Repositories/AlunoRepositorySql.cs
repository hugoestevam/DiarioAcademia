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
               ([Endereco_Cep]
               ,[Endereco_Bairro]
               ,[Endereco_Localidade]
               ,[Endereco_Uf]
               ,[Nome]
               ,[Turma_Id])
         VALUES
               ({0}Endereco_Cep,
                {0}Endereco_Bairro,
                {0}Endereco_Localidade,
                {0}Endereco_Uf,
                {0}Nome,
                {0}Turma_Id)";

        public const string SqlUpdate =
        @"UPDATE TBAluno SET
                [Endereco_Cep] = {0}Endereco_Cep
               ,[Endereco_Bairro] = {0}Endereco_Bairro
               ,[Endereco_Localidade] = {0}Endereco_Localidade
               ,[Endereco_Uf] = {0}Endereco_Uf
               ,[Nome] = {0}Nome
               ,[Turma_Id] = {0}Turma_Id
          WHERE [Id] = {0}id";

        public const string SqlDelete =
         "DELETE FROM TBAluno " +
                       "WHERE Id = {0}id";

        public const string SqlSelect =
         "SELECT * FROM TBAluno";

        public const string SqlSelectById =
        "SELECT * FROM TBAluno WHERE Id = {0}id";

        #endregion Querys

        public AlunoRepositorySql(AdoNetFactory factory) : base(factory)
        {
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
            return GetAll(SqlSelect, Make);
        }

        public Aluno GetById(int id)
        {
            var parms = new object[] { "id", id };

            return Get(SqlSelectById, Make, parms);
        }

        public void Update(Aluno entity)
        {
            Update(SqlUpdate, Take(entity));
        }

        private static Aluno Make(IDataReader reader)
        {
            Aluno aluno = new Aluno();
            aluno.Id = Convert.ToInt32(reader["Id"]);
            aluno.Nome = Convert.ToString(reader["Nome"]);
            aluno.Turma.Id = Convert.ToInt32(reader["Turma_Id"]);
            aluno.Endereco.Cep = Convert.ToString(reader["Endereco_Cep"]);
            aluno.Endereco.Localidade = Convert.ToString(reader["Endereco_Localidade"]);
            aluno.Endereco.Bairro = Convert.ToString(reader["Endereco_Bairro"]);
            aluno.Endereco.Uf = Convert.ToString(reader["Endereco_Uf"]);

            return aluno;
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