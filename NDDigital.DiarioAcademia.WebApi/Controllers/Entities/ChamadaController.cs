using Infrastructure.DAO.ORM.Common;
using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories;
using NDDigital.DiarioAcademia.WebApi.Controllers.Base;
using NDDigital.DiarioAcademia.WebApi.Filters;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Entities
{
    [GrouperAuthorize(Claim.Manager)]
    public class ChamadaController : BaseEntityController
    {
        private AulaService _aulaService;

        public ChamadaController() 
        {
            _aulaService = new AulaService(AulaRepository, AlunoRepository, TurmaRepository, Uow);
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