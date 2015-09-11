using Microsoft.AspNet.Identity;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using System.Web.Http;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using NDDigital.DiarioAcademia.WebApi.Controllers.Base;
using NDDigital.DiarioAcademia.WebApi.Filters;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Authentication
{
    [RoutePrefix("api/authentication")]
    [GrouperAuthorize(Claim.Manager)]
    public class AuthorizationController : BaseSecurityController
    {
        private IAuthorizationService _authservice;

        public AuthorizationController()
        {
            _authservice = new AuthorizationService(GroupRepository, PermissionRepository, AccountRepository, Uow);
        }

        [Route("addpermission/{groupId:int}")]
        public IHttpActionResult AddPermissionsToGroup(int groupId, [FromBody]string[] permissions)
        {
            _authservice.AddPermissionsToGroup(groupId, permissions);
            return Ok();
        }

        [Route("removepermission/{groupId:int}")]
        public IHttpActionResult RemovePermissionsToGroup(int groupId, [FromBody]string[] permissions)
        {
            _authservice.RemovePermissionsFromGroup(groupId, permissions);
            return Ok();
        }

        [Route("addgroup/{username}")]
        public IHttpActionResult AddGroupToUser(string username, [FromBody]int[] groups)
        {
            _authservice.AddGroupToUser(username, groups);
            return Ok();
        }

        [Route("removegroup/{username}")]
        public IHttpActionResult removeGroupToUser(string username, [FromBody]int[] groups)
        {
            _authservice.RemoveGroupFromUser(username, groups);
            return Ok();
        }

        [Route("isAuthorized/{username}")]
        public IHttpActionResult isAuthorized(string username, [FromBody]string[] permissions)
        {
            return Ok(_authservice.IsAuthorized(username, permissions));
        }

    }
}
