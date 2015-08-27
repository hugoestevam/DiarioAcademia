using Infrastructure.DAO.ORM.Common;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Factorys;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using System.Threading.Tasks;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Authentication
{
    public class PermissionController : BaseApiController
    {
        IPermissionService _permissionService;

        public PermissionController() //TODO: IOC
        {
            var factory = new EntityFrameworkFactory();

            var unitOfWork = new EntityFrameworkUnitOfWork(factory);

            var permissionRepo = new PermissionRepository(factory); //Container.Get<IPermissionRepository>();

            _permissionService = new PermissionService(permissionRepo, unitOfWork);

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

        public IHttpActionResult Post([FromBody]Permission[] values)
        {

            foreach (var item in values)
            
               _permissionService.Add(item);
            
            return Ok(values);
        }

        // DELETE: api/Permission/
        public IHttpActionResult Delete([FromBody]string[] ids)
        {
            if(ids == null)
                return BadRequest();
            foreach (var id in ids)
            {
                var permission = _permissionService.GetByPermissionId(id);

                _permissionService.Delete(permission.Id);

            }
            return Ok();
        }
    }
}