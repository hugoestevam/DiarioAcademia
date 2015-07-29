using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers
{
    public class GroupController : ApiController
    {
        private List<Group> Groups { get; set; }

        public GroupController()
        {
            var alunoList = new Permission { Name = "aluno.list" };
            var alunoEdit = new Permission { Name = "aluno.edit" };
            var alunoCreate = new Permission { Name = "aluno.create" };

            Groups = new List<Group>()
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
                    Name = "Viwer",
                    Permissions = new List<Permission>
                    {
                        alunoList,
                    }
                }
            };
        }

        // GET: api/Group
        public IHttpActionResult Get()
        {
            return Ok(Groups);
        }

        // GET: api/Group/bca443c4a
        public IHttpActionResult Get(Guid id)
        {
            return Ok(Groups.First(g => g.Id == id));
        }

        // GET: api/Group/username
        public IHttpActionResult Get(string username)
        {
            //provisorio
            return Ok(new List<Group>{Groups[0]});
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

    public class Group
    {
        public Group()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public List<ApplicationIdentityUser> User { get; set; }
        public List<Permission> Permissions { get; set; }
    }

    public class Permission
    {
        public Permission()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class ApplicationIdentityUser
    {
        public string Name { get; set; }
        public List<Group> Groups { get; set; }
    }
}