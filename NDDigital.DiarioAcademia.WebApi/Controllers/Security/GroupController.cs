using Microsoft.AspNet.Identity;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Repositories;
using NDDigital.DiarioAcademia.WebApi.Controllers.Base;
using System;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Authentication
{
    public class GroupController : BaseSecurityController
    {
        private IGroupService _groupService;

        public GroupController()
        {
            _groupService = new GroupService(GroupRepository, Uow);
        }

        // GET: api/Group
        [Authorize]
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
            var list = _groupService.GetByUser(username);

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