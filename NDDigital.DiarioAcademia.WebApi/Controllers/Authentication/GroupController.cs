using Infrastructure.DAO.ORM.Common;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Factorys;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using System;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Authentication
{
    public class GroupController : BaseApiController
    {
        private IGroupService _groupService;
        private IAccountService _userService;

        public GroupController() //TODO: IOC
        {
            var factory = new EntityFrameworkFactory();

            var unitOfWork = new EntityFrameworkUnitOfWork(factory);

            var groupRepository = new GroupRepository(factory); //Container.Get<IGroupRepository>();

            var permissionRepository = new PermissionRepository(factory); //Container.Get<IPermissionRepository>();

            _groupService = new GroupService(groupRepository, unitOfWork);

            var context = factory.Get();

            var store = new MyAccountStore(context);

            var userRepo = new AccountRepository(store);

            var userRepository = new AccountRepository(store);

            _userService = new AccountService(userRepository);
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