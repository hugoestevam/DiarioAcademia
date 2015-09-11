using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Base
{
    public class BaseEntityController : BaseApiController
    {
        protected IAulaRepository AulaRepository;
        protected IAlunoRepository AlunoRepository;
        protected ITurmaRepository TurmaRepository;

        public BaseEntityController()
        {
            AulaRepository = Injection.Get<IAulaRepository>();
            AlunoRepository = Injection.Get<IAlunoRepository>();
            TurmaRepository = Injection.Get<ITurmaRepository>();
        }
    }
}