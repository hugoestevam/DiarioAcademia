using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories;

namespace NDDigital.DiarioAcademia.WebApi.Controllers
{
    public class AulaController : ApiController
    {
         private AulaService _aulaService;

         public AulaController()
        {
            var factory = new DatabaseFactory();

            var unitOfWork = new UnitOfWork(factory);

            var aulaRepository = new AulaRepository(factory);
            var turmaRepository = new TurmaRepository(factory);
            var alunoRepository = new AlunoRepository(factory);

            _aulaService = new AulaService(aulaRepository, alunoRepository, turmaRepository, unitOfWork);
        }

        // GET: api/Aula
        public IEnumerable<AulaDTO> Get()
        {
            return _aulaService.GetAll();
        }

        // GET: api/Aula/5
        public AulaDTO Get(int id)
        {
            return _aulaService.GetById(id);
        }

        // POST: api/Aula
        public void Post([FromBody]AulaDTO value)
        {
            _aulaService.Add(value);
        }


        // PUT: api/Aula/5
        public void Put(int id, [FromBody]AulaDTO value)
        {

        }

        // DELETE: api/Aula/5
        public void Delete(int id)
        {
            _aulaService.Delete(id);
        }
    }
}
