using NDDigital.DiarioAcademia.Infraestrutura.Orm.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers
{
    public class GroupController : ApiController
    {
        private static Permission alunoList = new Permission { Name = "aluno.list", PermissionId ="01" };
        private static Permission alunoEdit = new Permission { Name = "aluno.details", PermissionId = "02" };
        private static Permission alunoCreate = new Permission { Name = "aluno.create", PermissionId= "03" };

        private static List<Group> Groups = new List<Group>()
            {
                new Group
                {
                    Name = "Administrators",
                    Permissions = new List<Permission>
                    {
                        alunoList,
                        alunoEdit,
                        alunoCreate
                    },
                    IsAdmin = true
                },
                new Group
                {
                    Name = "Editor",
                    Permissions = new List<Permission>
                    {
                        alunoList,
                        alunoEdit,
                    }
                },
                new Group
                {
                    Name = "Viewr",
                    Permissions = new List<Permission>
                    {
                        alunoList,
                    }
                }
            };

        // GET: api/Group
        public IHttpActionResult Get()
        {
            return Ok(Groups);
        }

        // GET: api/Group/bca443c4a
        public IHttpActionResult Get(Guid id)
        {
            return Ok(Groups.FirstOrDefault(g => g.Id.CompareTo(id) == 0 ));
        }

        // GET: api/Group/username
        public IHttpActionResult Get(string username)
        {
            //provisorio
            return Ok(new List<Group> { Groups[0] });
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