using Infrastructure.DAO.ORM.Common;
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
        private IAuthorizationService _authservice;

        public AccountsController()//TODO: IOC
        {
            var factory = new EntityFrameworkFactory();

            var unitOfWork = new EntityFrameworkUnitOfWork(factory);

            var groupRepository = new GroupRepository(factory); //Container.Get<IGroupRepository>();

            var permissionRepository = new PermissionRepository(factory); //Container.Get<IPermissionRepository>();

            var store = new MyUserStore(factory.Get());

            var userRepository = new UserRepository(store);

            var accountRepository = new AccountRepository(factory);

            _authservice = new AuthorizationService(groupRepository, permissionRepository,accountRepository, unitOfWork);
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
            var user = this.UserRepository.GetUserById(Id);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        //[Authorize(Roles = "Admin")]
        [Route("user/username/{username}")]
        public async Task<IHttpActionResult> GetUserByName(string username)
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            var user = this.UserRepository.GetUserByUsername(username);

            if (user != null)
            {
                return Ok(user);
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

        [HttpPut]
        [Route("edit")]
        public IHttpActionResult EditUser([FromBody] User user)
        {
            var u = UserRepository.GetUserByUsername(user.UserName);

            u.FirstName = user.FirstName;
            u.LastName = user.LastName;

            UserRepository.Update(u);

            return Ok(u);
        }
    }
}