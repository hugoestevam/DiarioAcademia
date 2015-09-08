using Microsoft.AspNet.Identity;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace NDDigital.DiarioAcademia.WebApi.Filters
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private IAuthorizationService _authservice;

        public CustomAuthorizeAttribute()
        {
            var unitOfWork = Injection.Get<IUnitOfWork>();

            var groupRepository = Injection.Get<IGroupRepository>();

            var permissionRepository = Injection.Get<IPermissionRepository>();

            var store = Injection.Get<IUserStore<User>>();// var store = new MyUserStore(factory.Get());

            var accountRepository = Injection.Get<IAccountRepository>(); // var accountRepository = new AccountRepository(factory);            

            _authservice = new AuthorizationService(groupRepository, permissionRepository, accountRepository, unitOfWork);

        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            try
            {
                var username = actionContext.Request.RequestUri.Query.Split('=')[1];

                //_authservice.IsAuthorized(); 
            }
            catch (Exception)
            {

                throw;
            }



            return base.IsAuthorized(actionContext);
        }
    }
}