using NDDigital.DiarioAcademia.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Exceptions;
using System.Data;

namespace NDDigital.DiarioAcademia.Infraestrutura.SQL.Repositories
{
    public class AulaRepositoryImpl : IAulaRepository
    {
        #region Querys

        public const string SqlInsert =
            "INSERT INTO TBAula (DataAula) " +
                         "VALUES ({0}DataAula)";

        public const string SqlUpdate =
         "UPDATE TBAula SET DataAula = {0}DataAula " +
                      "WHERE Id = {0}Id";

        public const string SqlDelete =
         "DELETE FROM TBAula " +
                       "WHERE Id = {0}Id";

        public const string SqlSelect =
         "SELECT * FROM TBAula";

        public const string SqlSelectbId =
        "SELECT * FROM TBAula WHERE Id = {0}Id";

        public const string SqlSelectTexto =
         "SELECT * FROM TBAula WHERE DataAula = {0}DataAula";

        #endregion Querys

        public Aula Add(Aula entity)
        {
            try
            {
                Db.Insert(SqlInsert, Take(entity));
            }
            catch (AulaException te)
            {
                throw new AulaException("Erro ao tentar adicionar uma Aula!" + te.Message);
            }
            return entity;
        }

        public void Delete(int id)
        {
            try
            {
                var aulaRemovida = GetById(id);
                Db.Delete(SqlDelete, Take(aulaRemovida));
            }
            catch (AulaException te)
            {
                throw new AulaException("Erro ao tentar deletar uma Aula!" + te.Message);
            }
        }

        public void Delete(Aula entity)
        {
            try
            {
                var aulaRemovida = GetById(entity.Id);
                Db.Delete(SqlDelete, Take(aulaRemovida));
            }
            catch (AulaException te)
            {
                throw new AulaException("Erro ao tentar deletar uma Aula!" + te.Message);
            }
        }

        public IEnumerable<Aula> GetAll()
        {
            try
            {
                return Db.GetAll<Aula>(SqlSelect, Make);
            }
            catch (AulaException te)
            {
                throw new AulaException("Erro ao tentar listar todas as Aulas!" + te.Message);
            }
        }

        public IEnumerable<Aula> GetAllByTurma(int ano)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Aula> GetAllIncluding(params Expression<Func<Aula, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Aula GetByData(DateTime data)
        {
            throw new NotImplementedException();
        }

        public Aula GetById(int id)
        {
            try
            {
                var parms = new object[] { "Id", id };

                return Db.Get(SqlSelectbId, Make, parms);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Aula GetByIdIncluding(int id, params Expression<Func<Aula, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Aula> GetMany(Expression<Func<Aula, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(Aula entity)
        {
            try
            {
                var aulaEditada = GetById(entity.Id);
                Db.Update(SqlUpdate, Take(aulaEditada));
            }
            catch (AulaException te)
            {
                throw new AulaException("Erro ao tentar editar uma Aula!" + te.Message);
            }
        }

        private static Aula Make(IDataReader reader)
        {
            Aula aula = new Aula();

            aula.Id = Convert.ToInt32(reader["Id"]);
            aula.Data = Convert.ToDateTime(reader["DataAula"]);

            return aula;
        }

        private static object[] Take(Aula aula)
        {
            return new object[]
            {
                "Id", aula.Id,
                "DataAula", aula.Data,
            };
        }
    }
}
