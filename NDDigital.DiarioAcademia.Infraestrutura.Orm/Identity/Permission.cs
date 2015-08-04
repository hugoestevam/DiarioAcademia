using System;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Identity
{
    public class Permission
    {
        public Permission()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PermissionId { get; set; }
    }
}