using NDDigital.DiarioAcademia.Dominio.Common;

namespace NDDigital.DiarioAcademia.Infraestrutura.Security.Entities
{
    public class Permission : Entity
    {
        public string PermissionId { get; set; }

        public override string ToString()
        {
            return PermissionId;
        }

        public Permission()
        {
        }

        public Permission(string id)
        {
            PermissionId = id;
        }
    }
}