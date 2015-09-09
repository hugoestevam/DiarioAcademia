using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
