using Infrastructure.DAO.ORM.Common;
using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Entities
{
    public class ChamadaController : ApiController
    {
        private AulaService _aulaService;

        public ChamadaController() //TODO: IOC
        {
            var factory = new EntityFrameworkFactory();

            var unitOfWork = new EntityFrameworkUnitOfWork(factory);

            var alunoRepository = new AlunoRepositoryEF(factory); //Container.Get<IAlunoRepository>();

            var turmaRepository = new TurmaRepositoryEF(factory); //Container.Get<ITurmaRepository>();

            var aulaRepository = new AulaRepositoryEF(factory); //Container.Get<IAulaRepository>();

            _aulaService = new AulaService(aulaRepository, alunoRepository, turmaRepository, unitOfWork);
        }

        // GET: api/Chamada
        public ChamadaDTO Get(int id)
        {
            var aulaDto = _aulaService.GetById(id);
            return _aulaService.GetChamadaByAula(aulaDto);
        }

        // POST: api/Chamada
        public void Post([FromBody]ChamadaDTO value)
        {
            _aulaService.RealizaChamada(value);
        }

        // PUT: api/Chamada/5
        public void Put(int id, [FromBody] ChamadaDTO value)
        {
        }

        // DELETE: api/Chamada/5
        public void Delete(int id)
        {
        }
    }
}