using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using System.Data.Entity.ModelConfiguration;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Configurations
{
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("TBUser");
            Ignore(c => c.EmailConfirmed);
        }
    }
}