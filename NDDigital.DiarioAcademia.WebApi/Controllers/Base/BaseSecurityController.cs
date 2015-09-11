using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Base
{
    public class BaseSecurityController : BaseApiController
    {
        protected IPermissionRepository PermissionRepository;
        protected IGroupRepository GroupRepository;
        protected IAccountRepository AccountRepository;

        public BaseSecurityController()
        {
            PermissionRepository = Injection.Get<IPermissionRepository>();
            GroupRepository = Injection.Get<IGroupRepository>();
            AccountRepository = Injection.Get<IAccountRepository>();
        }
    }
}