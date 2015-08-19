using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using System;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Authentication
{
    public class GroupController : BaseApiController
    {
        IGroupService _groupService;
        IUserService _userService;

        public GroupController()
        {

            var factory = new DatabaseFactory();

        var    uow = new UnitOfWork(factory);

            var groupRepo = new GroupRepository(factory);

            _groupService = new GroupService(groupRepo,uow);

            var context = factory.Get();

            var store = new MyUserStore(context);

            var userRepo = new UserRepository(store);

            _userService = new UserService(userRepo);
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
                group = _groupService.GetById(id);

                group.Name = value.Name;

                _groupService.Update(group);
            }
            catch (Exception ex)
            {
                for (;ex.InnerException!=null ; ex = ex.InnerException) { }
                    throw ex;
            }

            return Ok(group);
        }

        // DELETE: api/Group/5
        public void Delete(int id)
        {
            _groupService.Delete(id);

        }
    }
}