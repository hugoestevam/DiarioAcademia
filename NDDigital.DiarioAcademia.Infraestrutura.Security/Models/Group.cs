using NDDigital.DiarioAcademia.Dominio.Common;
using System;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Identity
{
    public class Group : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public List<ApplicationUser> User { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}