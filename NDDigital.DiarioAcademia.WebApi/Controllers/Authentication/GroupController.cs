using Microsoft.AspNet.Identity;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using System;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Authentication
{
    public class GroupController : BaseApiController
    {
        private IGroupService _groupService;
        private IUserService _userService;

        public GroupController() //TODO: IOC
        {
            var unitOfWork = Injection.Get<IUnitOfWork>();

            var groupRepository = Injection.Get<IGroupRepository>();

            var permissionRepository = Injection.Get<IPermissionRepository>();

            var store = Injection.Get<IUserStore<User>>();// var store = new MyUserStore(factory.Get());

            var accountRepository = Injection.Get<IAccountRepository>(); // var accountRepository = new AccountRepository(factory);

            _groupService = new GroupService(groupRepository, unitOfWork);

            //var context = factory.Get();

            //var store = new MyUserStore(context);

            var userRepo = new UserRepository(store);

            var userRepository = new UserRepository(store);

            _userService = new UserService(userRepository);
        }

        // GET: api/Group
        public IHttpActionResult Get()
        {
            return Ok(_groupService.GetAll());
        }

        // GET: api/Group/1
        public IHttpActionResult Get(int id)
        {
            return Ok(_groupService.GetById(id));
        }

        // GET: api/Group?username=username
        public IHttpActionResult Get(string username)
        {
            var list = _userService.FindGroupByUsername(username);

            return Ok(list);
        }

        // POST: api/Group
        public IHttpActionResult Post([FromBody]Group value)
        {
            _groupService.Add(value);
            return Ok(value);
        }

        // PUT: api/Group/5
        public IHttpActionResult Put(int id, [FromBody]Group value)
        {
            Group group;
            try
            {
                _groupService.Update(value);
            }
            catch (Exception ex)
            {
                for (; ex.InnerException != null; ex = ex.InnerException) { }
                throw ex;
            }

            return Ok(value);
        }

        // DELETE: api/Group/5
        public void Delete(int id)
        {
            _groupService.Delete(id);
        }
    }
}