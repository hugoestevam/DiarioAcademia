﻿using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using NDDigital.DiarioAcademia.WebApi.Controllers.Base;
using NDDigital.DiarioAcademia.WebApi.Filters;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Authentication
{
    [RoutePrefix("api/permission")]
    [GrouperAuthorize(Claim.Manager_Permission)]
    public class PermissionController : BaseSecurityController
    {
        private IPermissionService _permissionService;

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

        // GET: api/Permission/byuser/username
        [Route("byuser/{username}")]
        public IHttpActionResult GetByUser(string username)
        {
            return Ok(_permissionService.GetByUser(username));
        }

        [Route("byuser/{groupId:int}")]
        // GET: api/Permission/bygroup/groupId
        public IHttpActionResult GetByGroup(int groupId)
        {
            return Ok(_permissionService.GetByGroup(groupId));
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
            if (ids == null)
                return BadRequest();


            _permissionService.DeleteAll(ids);
            
                
                return Ok();
        }
    }
}