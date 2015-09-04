using NDDigital.DiarioAcademia.Dominio.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Infraestrutura.Security.Entities
{
    public class Group : Entity
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public List<Permission> Permissions { get; set; }

        public Group()
        {
            Permissions = new List<Permission>();
        }

        public override string ToString()
        {
            return Name + (IsAdmin ? " [Admin]" : "");
        }
        public override bool Equals(object obj)
        {
            var group = obj as Group;

            if (group == null) return false;

            return group.Id == this.Id;

        }
    }
}
