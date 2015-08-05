using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/permissions")]
    public class PermissionController : BaseApiController
    {
        [Route("{id:guid}", Name = "GetPermissionsById")]
        public async Task<IHttpActionResult> GetPermissions(string Id)
        {
          

            return NotFound();
        }

        [Route("", Name = "GetAllPermissions")]
        public IHttpActionResult GetAllPermissions()
        {
          

            return Ok();
        }

        [Route("create")]
        public async Task<IHttpActionResult> Create(CreateRoleBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = new IdentityRole { Name = model.Name };

 
            Uri locationHeader = new Uri(Url.Link("GetRoleById", new { id = role.Id }));

            return Created(locationHeader, TheModelFactory.Create(role));
        }

        [Route("{id:guid}")]
        public async Task<IHttpActionResult> DeletePermissions(string Id)
        {
           return NotFound();
        }

        [Route("ManageUsersInRole")]
        public async Task<IHttpActionResult> ManageUsersInPermissions(UsersInRoleModel model)
        {
            return Ok();
        }
    }
}