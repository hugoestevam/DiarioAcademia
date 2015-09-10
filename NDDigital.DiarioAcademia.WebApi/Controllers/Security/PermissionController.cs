using Infrastructure.DAO.ORM.Common;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Repositories;
using NDDigital.DiarioAcademia.WebApi.Controllers.Base;
using NDDigital.DiarioAcademia.WebApi.Filters;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Authentication
{
    [GrouperAuthorize(Claim.Manager_Permission)]
    public class PermissionController : BaseSecurityController
    {
        IPermissionService _permissionService;

        public PermissionController() 
        {
            _permissionService = new PermissionService(PermissionRepository, Uow);

        }

        // GET: api/Permission
        public IHttpActionResult Get()
        {
            return Ok(_permissionService.GetAll());
        }

        // GET: api/Permission/group-id
        public IHttpActionResult Get(int id)
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