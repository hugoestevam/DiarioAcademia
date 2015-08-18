using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using System.Threading.Tasks;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Authentication
{
    public class PermissionController : BaseApiController
    {
        IPermissionService _permissionService;

        public PermissionController()
        {

            var factory = new DatabaseFactory();

            var uow = new UnitOfWork(factory);

            var permissionRepo = new PermissionRepository(factory);

            _permissionService = new PermissionService(permissionRepo, uow);

        }

        // GET: api/Permission
        public IHttpActionResult Get()
        {
            return Ok(_permissionService.GetAll());
        }

        // GET: api/Permission/group-id
        public IHttpActionResult Get(int id)//neste caso e o id do grupo
        {
            return Ok(_permissionService.GetById(id));
        }

        // POST: api/Permission
        public IHttpActionResult Post([FromBody]Permission value)
        {
            _permissionService.Add(value);
            return Ok(value);
        }

        // DELETE: api/Permission/5
        public void Delete(string id)
        {
            var permission = _permissionService.GetByPermissionId(id);

            _permissionService.Delete(permission.Id);

        }
    }
}