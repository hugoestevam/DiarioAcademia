using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using System.Collections.Generic;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Entities
{
    public class AulaController : ApiController
    {
        private AulaService _aulaService;

        public AulaController() //TODO: IOC
        {
            var unitOfWork = Injection.Get<IUnitOfWork>();

            var alunoRepository = Injection.Get<IAlunoRepository>();

            var turmaRepository = Injection.Get<ITurmaRepository>();

            var aulaRepository = Injection.Get<IAulaRepository>();

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