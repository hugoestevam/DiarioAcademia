using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.ORM.Services;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers
{
    public class ChamadaController : ApiController
    {
        private AulaService _aulaService;

        public ChamadaController()
        {
            var factory = new DatabaseFactory();
            var aulaRespository = new AulaRepositoryEF(factory);
            var alunoRepository = new AlunoRepositoryEF(factory);
            var turmaRepository = new TurmaRepositoryEF(factory);
            var uow = new UnitOfWork(factory);

            _aulaService = new AulaService(aulaRespository, alunoRepository, turmaRepository, uow);
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