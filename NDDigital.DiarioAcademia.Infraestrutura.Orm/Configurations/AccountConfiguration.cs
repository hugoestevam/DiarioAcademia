using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using System.Data.Entity.ModelConfiguration;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Configurations
{
    internal class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            ToTable("TBAccount");
            Ignore(c => c.EmailConfirmed);
            HasMany(x => x.Groups)
            .WithMany()
           //TODO: Passa pra User
            .Map(x =>
            {
                x.ToTable("TBUserGroups");
            });
        }
    }
}