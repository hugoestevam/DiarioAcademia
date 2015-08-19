using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Authentication
{
    [RoutePrefix("api/authentication")]
    public class AuthorizationController : BaseApiController
    {

        IAuthorizationService _authservice;

        public AuthorizationController()
        {
            var factory = new DatabaseFactory();
            var uow = new UnitOfWork(factory);
            var groupRepository = new GroupRepository(factory);
            var permissionRepository = new PermissionRepository(factory);
            var store = new MyUserStore(factory.Get());
            var userRepository = new UserRepository(store);
            _authservice = new AuthorizationService(groupRepository, permissionRepository, userRepository, uow);
        }

        //[Authorize]
        [Route("addpermission/{groupId:int}")]
        public IHttpActionResult AddPermissionsToGroup(int groupId, [FromBody]string[] permissions)
        {
            _authservice.AddPermissionsToGroup(groupId, permissions);
            return Ok();
        }
        //[Authorize]
        [Route("removepermission/{groupId:int}")]
        public IHttpActionResult RemovePermissionsToGroup(int groupId, [FromBody]string[] permissions)
        {
            _authservice.RemovePermissionsFromGroup(groupId, permissions);
            return Ok();
        }
        //[Authorize]
        [Route("addgroup/{username}")]
        public IHttpActionResult AddGroupToUser(string username, [FromBody]int[] groups)
        {
            _authservice.AddGroupToUser(username, groups);
            return Ok();
        }
        //[Authorize]
        [Route("removegroup/{username}")]
        public IHttpActionResult removeGroupToUser(string username, [FromBody]int[] groups)
        {
            _authservice.RemoveGroupFromUser(username, groups);
            return Ok();
        }


    }
}
