using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using System;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers.Authentication
{
    public class GroupController : ApiController
    {

        // GET: api/Group
        public IHttpActionResult Get()
        {
            return Ok();
        }

        // GET: api/Group/bca443c4a
        public IHttpActionResult Get(Guid id)
        {
            return Ok();
        }

        // GET: api/Group/username
        public IHttpActionResult Get(string username)
        {
            //provisorio
            return Ok();
        }

        // GET: api/Group/username
        public IHttpActionResult Get(string username, string state)
        {
            //provisorio
            return Ok(true);
        }

        // POST: api/Group
        public void Post([FromBody]Group value)
        {
        }

        // PUT: api/Group/5
        public void Put(int id, [FromBody]Group value)
        {
        }

        // DELETE: api/Group/5
        public void Delete(int id)
        {
        }
    }
}