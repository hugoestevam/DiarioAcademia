using NDDigital.DiarioAcademia.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Dominio.Contracts;

namespace NDDigital.DiarioAcademia.Infraestrutura.SQL.Repositories
{
    public class AulaRepositoryImpl : IAulaRepository
    {
        public Aula Add(Aula entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Aula entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Aula> GetAll()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
