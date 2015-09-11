using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using System.Data.Entity.ModelConfiguration;

namespace NDDigital.DiarioAcademia.Infraestrutura.Security.Configurations
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