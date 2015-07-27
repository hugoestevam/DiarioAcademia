using NDDigital.DiarioAcademia.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using System.Data;
using NDDigital.DiarioAcademia.Dominio.Exceptions;

namespace NDDigital.DiarioAcademia.Infraestrutura.SQL.Repositories
{
    public class AlunoRepositoryImpl : IAlunoRepository
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
               ({0} Endereco_Cep,
                {0} Endereco_Bairro, 
                {0} Endereco_Localidade, 
                {0} Endereco_Uf, 
                {0} Nome, 
                {0}Turma_Id)";


        public const string SqlUpdate =
        @"UPDATE TBAluno SET
                [Endereco_Cep] = {0}Endereco_Cep
               ,[Endereco_Bairro] = {0}Endereco_Bairro
               ,[Endereco_Localidade] = {0}Endereco_Localidade
               ,[Endereco_Uf] = {0}Endereco_Uf
               ,[Nome] = = {0}Nome
               ,[Turma_Id] = {0}Turma_Id
         WHERE [Id] = {0}Id";

        public const string SqlDelete =
         "DELETE FROM TBAluno " +
                       "WHERE Id = {0}Id";

        public const string SqlSelect =
         "SELECT * FROM TBAluno";

        public const string SqlSelectbId =
        "SELECT * FROM TBAluno WHERE Id = {0}Id";

        #endregion

        public Aluno Add(Aluno entity)
        {
            try
            {
                Db.Insert(SqlInsert, Take(entity));
            }
            catch (AlunoNaoEncontrado te)
            {
                throw new AlunoNaoEncontrado("Erro ao tentar adicionar um Aluno!" + te.Message);
            }

            return entity;
        }

        public void Delete(int id)
        {
            try
            {
                var alunoRemovido = GetById(id);
                Db.Delete(SqlDelete, Take(alunoRemovido));
            }
            catch (AlunoNaoEncontrado te)
            {
                throw new AlunoNaoEncontrado("Erro ao tentar deletar um Aluno!" + te.Message);
            }
        }

        public void Delete(Aluno entity)
        {
            try
            {
                Db.Delete(SqlDelete, Take(entity));
            }
            catch (AlunoNaoEncontrado te)
            {
                throw new AlunoNaoEncontrado("Erro ao tentar deletar um Aluno!" + te.Message);
            }
        }

        public IEnumerable<Aluno> GetAll()
        {
            try
            {
                return Db.GetAll<Aluno>(SqlSelect, Make);
            }
            catch (AlunoNaoEncontrado te)
            {
                throw new AlunoNaoEncontrado("Erro ao tentar listar todos os Alunos!" + te.Message);
            }
        }

        public IEnumerable<Aluno> GetAllByTurma(int ano)
        {
            throw new NotImplementedException();
            //TODO: 1 Implementar
        }

        public IEnumerable<Aluno> GetAllByTurmaId(int id)
        {
            throw new NotImplementedException();
            //TODO: 2 Implementar
        }

        public IEnumerable<Aluno> GetAllIncluding(params Expression<Func<Aluno, object>>[] includeProperties)
        {
            throw new NotImplementedException();
            //TODO: 3 Implementar
        }

        public Aluno GetById(int id)
        {
            try
            {
                var parms = new object[] { "Id", id };

                return Db.Get(SqlSelectbId, Make, parms);
            }
            catch (AlunoNaoEncontrado te)
            {
                throw new AlunoNaoEncontrado("Erro ao tentar buscar um Aluno!" + te.Message);
            }
        }

        public Aluno GetByIdIncluding(int id, params Expression<Func<Aluno, object>>[] includeProperties)
        {
            throw new NotImplementedException();
            //TODO: 4 Implementar
        }

        public IEnumerable<Aluno> GetMany(Expression<Func<Aluno, bool>> where)
        {
            throw new NotImplementedException();
            //TODO: 5 Implementar
        }

        public void Update(Aluno entity)
        {
            try
            {
                var alunoEditado = GetById(entity.Id);
                Db.Update(SqlUpdate, Take(alunoEditado));
            }
            catch (AlunoNaoEncontrado te)
            {
                throw new AlunoNaoEncontrado("Erro ao tentar editar um Aluno!" + te.Message);
            }
        }

        private static Aluno Make(IDataReader reader)
        {
            Aluno aluno = new Aluno();
            aluno.Id = Convert.ToInt32(reader["Id"]);
            aluno.Nome = Convert.ToString(reader["Nome"]);
            aluno.Turma.Id = Convert.ToInt32(reader["TurmaId"]); //TODO: Tirei o protected da Entity

            return aluno;
        }

        private static object[] Take(Aluno aluno)
        {
            return new object[]
            {
                "Id", aluno.Id,
                "Nome", aluno.Nome,
                "TurmaId", aluno.Turma.Id,
                "Cep", aluno.Endereco.Cep,
                "Localidade", aluno.Endereco.Localidade,
                "Bairro", aluno.Endereco.Bairro,
                "UF", aluno.Endereco.Uf
            };
        }
    }
}
