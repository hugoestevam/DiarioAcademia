using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.WebApi.Controllers.Base;
using NDDigital.DiarioAcademia.WebApi.Filters;
using System.Collections.Generic;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Entities
{
    [GrouperAuthorize(Claim.Aluno)]
    public class AlunoController : BaseEntityController
    {
        private AlunoService _alunoService;

        public AlunoController()
        {
            _alunoService = new AlunoService(AlunoRepository, TurmaRepository, Uow);
        }

        // GET: api/Aluno
        public IEnumerable<AlunoDTO> Get()
        {
            var list = _alunoService.GetAll();
            return list;
        }

        [GrouperAuthorize(Claim.Aluno_Details)]
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