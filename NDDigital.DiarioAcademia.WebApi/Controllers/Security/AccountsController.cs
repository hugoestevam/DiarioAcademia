using Ellevo.Biblioteca.Seguranca;
using Microsoft.AspNet.Identity;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Repositories;
using NDDigital.DiarioAcademia.WebApi.Controllers.Base;
using NDDigital.DiarioAcademia.WebApi.Filters;
using NDDigital.DiarioAcademia.WebApi.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

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
        }

        [Route("user/{id:guid}", Name = "GetUserById")]
        public async Task<IHttpActionResult> GetUser(string Id)
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            var user = this.UserRepository.GetUserById(Id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [Route("user/username/{username}")]
        [GrouperAuthorize(Basic = true)]
        public IHttpActionResult GetUserByName(string username)
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            var user = this.UserRepository.GetUserByUsername(username);
            if (user == null)
                return NotFound();
            var model = TheModelFactory.Create(user);
            model.IsAdmin = _groupService.isAdmin(username);
            model.Permissions = _permissionService.GetByUser(username);
            return Ok(model);
        }

        [AllowAnonymous]
        [Route("create")]
        //public async Task<IHttpActionResult> CreateUser(CreateUserBindingModel createUserModel)
        public IHttpActionResult CreateUser(CreateUserBindingModel model)
        {
            if (!ModelState.IsValid || model== null)
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

        [Route("user/{id:guid}")]
        public async Task<IHttpActionResult> DeleteUser(string id)
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)

                UserRepository.Delete(id);


            return Ok();
        }

        [Route("edit")]
        public IHttpActionResult EditUser([FromBody] User user)
        {
            if (user == null) return BadRequest();

            var u = UserRepository.GetUserByUsername(user.UserName);

            u.FirstName = user.FirstName;
            u.LastName = user.LastName;

            UserRepository.Update(u);

            return Ok(u);
        }
    }
}