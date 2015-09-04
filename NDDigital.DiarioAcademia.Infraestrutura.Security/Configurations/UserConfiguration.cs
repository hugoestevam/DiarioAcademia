using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;

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
