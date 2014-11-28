using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers
{
    public class TurmaController : ApiController
    {
        private TurmaService _turmaService;
      
        public TurmaController()
        {
            var factory = new DatabaseFactory();

            var unitOfWork = new UnitOfWork(factory);
          
            var turmaRepository = new TurmaRepository(factory);

            _turmaService = new TurmaService(turmaRepository, unitOfWork);
        }


        // GET: api/Turma
        public IEnumerable<TurmaDTO> Get()
        {
            return _turmaService.GetAll();
        }

        // GET: api/Turma/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Turma
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Turma/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Turma/5
        public void Delete(int id)
        {
        }
    }
}
