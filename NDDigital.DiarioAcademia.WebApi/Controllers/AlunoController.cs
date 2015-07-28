using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.ORM.Services;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers
{
    public class AlunoController : ApiController
    {
        private AlunoService _alunoService;

        public AlunoController()
        {
            var factory = new DatabaseFactory();

            var alunoRespository = new AlunoRepository(factory);

            var turmaRepository = new TurmaRepository(factory);

            var uow = new UnitOfWork(factory);

            _alunoService = new AlunoService(alunoRespository, turmaRepository, uow);
        }

        // GET: api/Aluno
        [Authorize]
        public IEnumerable<AlunoDTO> Get()
        {
            return _alunoService.GetAll();
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