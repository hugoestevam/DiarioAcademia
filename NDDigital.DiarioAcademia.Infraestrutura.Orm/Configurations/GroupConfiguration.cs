using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using System.Data.Entity.ModelConfiguration;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Configurations
{
    internal class GroupConfiguration : EntityTypeConfiguration<Group>
    {
        public GroupConfiguration()
        {
            ToTable("TBGroup");

            HasMany(x => x.Permissions).WithMany().Map(x =>
            {
                x.ToTable("TBGroupPermission");
            });
        }            
    }
}