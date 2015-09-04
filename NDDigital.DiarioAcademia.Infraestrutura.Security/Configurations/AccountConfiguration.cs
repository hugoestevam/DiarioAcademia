using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Infraestrutura.Security.Configurations
{
    internal class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            ToTable("TBAccount");
            HasMany(x => x.Groups)
            .WithMany()
            .Map(x =>
            {
                x.ToTable("TBAccountGroups");
            });
        }
    }
}
