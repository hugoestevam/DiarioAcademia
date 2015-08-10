using NDDigital.DiarioAcademia.Dominio.Common;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Dominio.Entities.Security
{
    public class Group : Entity
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}