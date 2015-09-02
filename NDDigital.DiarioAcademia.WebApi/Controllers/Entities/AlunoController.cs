using Infrastructure.DAO.ORM.Common;
using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Factorys;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Entities
{
    public class AlunoController : ApiController
    {
        private AlunoService _alunoService;

        public AlunoController() //TODO: IOC
        {
            var factory = new EntityFrameworkFactory();

            var unitOfWork = new EntityFrameworkUnitOfWork(factory);

            var alunoRepository = new AlunoRepositoryEF(factory); //Container.Get<IAlunoRepository>();

            var turmaRepository = new TurmaRepositoryEF(factory); //Container.Get<ITurmaRepository>();

            _alunoService = new AlunoService(alunoRepository, turmaRepository, unitOfWork);
        }

        // GET: api/Aluno
        public IEnumerable<AlunoDTO> Get()
        {
            var list = _alunoService.GetAll();
            return list;
        }

        // GET: api/Aluno/5
        public AlunoDTO Get(int id)
        {
            return _alunoService.GetById(id);
        }

        // POST: api/Aluno
        public IHttpActionResult Post([FromBody]AlunoDTO value)
        {
            _alunoService.Add(value);
            return Ok();
        }

        // PUT: api/Aluno/5
        public IHttpActionResult Put(int id, [FromBody]AlunoDTO value)
        {
            value.Id = id;
            _alunoService.Update(value);

            return Ok();
        }

        // DELETE: api/Aluno/5
        public IHttpActionResult Delete(int id)
        {
            _alunoService.Delete(id);
            return Ok();
        }
    }
}