using System;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Identity
{
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
}