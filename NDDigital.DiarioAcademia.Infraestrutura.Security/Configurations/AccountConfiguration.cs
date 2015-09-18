using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using System.Data.Entity.ModelConfiguration;

namespace NDDigital.DiarioAcademia.Infraestrutura.Security.Configurations
{
    internal class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            ToTable("TBAccount");
            Property(a => a.Username)
                .IsConcurrencyToken();
            HasMany(a => a.Groups)
            .WithMany()
            
            .Map(x =>
            {
                x.ToTable("TBAccountGroups");
            });


        }
    }
}