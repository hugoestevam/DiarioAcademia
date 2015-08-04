using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/roles")]
    public class PermissionController : BaseApiController
    {
        [Route("{id:guid}", Name = "GetRoleById")]
        public async Task<IHttpActionResult> GetRole(string Id)
        {
          

            return NotFound();
        }

        [Route("", Name = "GetAllRoles")]
        public IHttpActionResult GetAllRoles()
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
        public async Task<IHttpActionResult> DeleteRole(string Id)
        {
           return NotFound();
        }

        [Route("ManageUsersInRole")]
        public async Task<IHttpActionResult> ManageUsersInRole(UsersInRoleModel model)
        {
            return Ok();
        }
    }
}