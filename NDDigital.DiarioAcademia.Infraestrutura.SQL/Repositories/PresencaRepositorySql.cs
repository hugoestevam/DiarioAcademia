using Infrasctructure.DAO.SQL.Common;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.SQL.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NDDigital.DiarioAcademia.Infraestrutura.SQL.Repositories
{
    //TODO: IMPLEMENTAR
    public class PresencaRepositorySql : RepositoryBaseADO, IPresencaRepository
    {
        #region Querys

        public const string SqlDelete =
         "DELETE FROM TBPresenca " +
                       "WHERE Id = {0}Id";

        #endregion Querys

        public PresencaRepositorySql(AdoNetFactory factory) : base(factory)
        {
        }

        public Presenca Add(Presenca entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            try
            {
                var presencaRemovida = GetById(id);
                Delete(SqlDelete, Take(presencaRemovida));
            }
            catch (Exception te)
            {
                throw new Exception("Erro ao tentar deletar uma Presenca!" + te.Message);
            }
        }

        private static object[] Take(Presenca presenca)
        {
            return new object[]
            {
                "Id", presenca.Id,
                "Aluno_Id", presenca.Aluno.Id,
                "Aula_Id", presenca.Aula.Id,
                "StatusPresenca", presenca.StatusPresenca,
            };
        }

        public void Delete(Presenca entity)
        {
            throw new NotImplementedException();
        }

        public IList<Presenca> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<Presenca> GetAllIncluding(params Expression<Func<Presenca, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Presenca GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Presenca GetByIdIncluding(int id, params Expression<Func<Presenca, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IList<Presenca> GetMany(Expression<Func<Presenca, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(Presenca entity)
        {
            throw new NotImplementedException();
        }
    }
}