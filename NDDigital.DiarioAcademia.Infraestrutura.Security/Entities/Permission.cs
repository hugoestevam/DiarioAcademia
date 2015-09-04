using NDDigital.DiarioAcademia.Dominio.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Infraestrutura.Security.Entities
{
    public class Permission : Entity
    {
        public string PermissionId { get; set; }
        public override string ToString()
        {
            return PermissionId;
        }

        public Permission() { }
        public Permission(string id)
        {
            PermissionId = id;
        }
    }
}
