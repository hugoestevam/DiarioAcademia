using Microsoft.AspNet.Identity;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using NDDigital.DiarioAcademia.WebApi.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Authentication
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : BaseApiController
    {
        IAuthorizationService _authservice;

        public AccountsController()
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
        [Route("user")]
        public IHttpActionResult GetUsers()
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            var identity = User.Identity as System.Security.Claims.ClaimsIdentity;

            return Ok(this.UserRepository.Users.ToList().Select(u => this.TheModelFactory.Create(u)));
        }

        //[Authorize(Roles = "Admin")]
        [Route("user/{id:guid}", Name = "GetUserById")]
        public async Task<IHttpActionResult> GetUser(string Id)
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            var user = await this.UserRepository.FindByIdAsync(Id);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();
        }

        //[Authorize(Roles = "Admin")]
        [Route("user/username/{username}")]
        public async Task<IHttpActionResult> GetUserByName(string username)
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            var user = await this.UserRepository.FindByNameAsync(username);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();
        }


        [AllowAnonymous]
        [Route("create")]
        public async Task<IHttpActionResult> CreateUser(CreateUserBindingModel createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User()
            {
                UserName = createUserModel.Username,
                Email = createUserModel.Email,
                FirstName = createUserModel.FirstName,
                LastName = createUserModel.LastName,
                Level = 3,
            };

            IdentityResult addUserResult = await this.UserRepository.CreateAsync(user, createUserModel.Password);

            if (!addUserResult.Succeeded)
            {
                return GetErrorResult(addUserResult);
            }

            Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

            return Created(locationHeader, TheModelFactory.Create(user));
        }

        //[Authorize]
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await this.UserRepository.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
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

        //[Authorize(Roles = "Admin")]
        [Route("user/{id:guid}")]
        public async Task<IHttpActionResult> DeleteUser(string id)
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)

            var appUser = await this.UserRepository.FindByIdAsync(id);

            if (appUser != null)
            {
                IdentityResult result = await this.UserRepository.DeleteAsync(appUser);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                return Ok();
            }

            return NotFound();
        }
    }
}