using Microsoft.AspNet.Identity;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.WebApi.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Repositories;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Common;
using Microsoft.AspNet.Identity.EntityFramework;
using Ellevo.Biblioteca.Seguranca;
using NDDigital.DiarioAcademia.WebApi.Filters;
using NDDigital.DiarioAcademia.WebApi.Controllers.Base;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Authentication
{
    [RoutePrefix("api/accounts")]
    [GrouperAuthorize(Claim.Manager)]
    public class AccountsController : BaseSecurityController
    {
        private IAuthorizationService _authservice;
        private IPermissionService _permissionService;
        private IGroupService _groupService;


        public AccountsController()
        {
            _authservice = new AuthorizationService(GroupRepository, PermissionRepository, AccountRepository, Uow);
            _permissionService = new PermissionService(PermissionRepository, Uow);
            _groupService = new GroupService(GroupRepository, Uow);

        }

        [Route("user")]
        public IHttpActionResult GetUsers()
        {

            var users = UserRepository.GetUsers();

            return Ok(users.Select(u => TheModelFactory.Create(u)));


            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            //var identity = User.Identity as System.Security.Claims.ClaimsIdentity;
            //
            //return Ok(this.UserRepository.Users.ToList().Select(u => this.TheModelFactory.Create(u)));
        }

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
        
        [Route("user/username/{username}")]
        public IHttpActionResult GetUserByName(string username)
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            var user = this.UserRepository.GetUserByUsername(username);
            if (user != null)
            {
                var model = TheModelFactory.Create(user);
                model.IsAdmin = _groupService.isAdmin(username);
                model.Permissions = _permissionService.GetByUser(username);
                return Ok(model);
            }
            return NotFound();
        }

        [AllowAnonymous]
        [Route("create")]
        //public async Task<IHttpActionResult> CreateUser(CreateUserBindingModel createUserModel)
        public IHttpActionResult CreateUser(CreateUserBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User()
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PasswordHash = Criptografia.Criptografar(model.Password, Criptografia.ModoSimples.Padrao)

            };

            // IdentityResult addUserResult =  this.UserRepository.Create(user, createUserModel.Password);

            UserRepository.AddUser(user);

            // if (!addUserResult.Succeeded)
            // {
            //     return GetErrorResult(addUserResult);
            // }

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