using NDDigital.DiarioAcademia.Dominio.Common;
using System;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Dominio.Entities.Security
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public List<User> User { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}