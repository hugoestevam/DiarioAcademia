using NDDigital.DiarioAcademia.Dominio.Common;
using System;

namespace NDDigital.DiarioAcademia.Dominio.Entities.Security
{
    public class Permission : Entity
    {
        public string PermissionId { get; set; }
        public override string ToString()
        {
            return PermissionId;
        }

        public Permission(){}
        public Permission(string id)
        {
            PermissionId = id;
        }
    }
}