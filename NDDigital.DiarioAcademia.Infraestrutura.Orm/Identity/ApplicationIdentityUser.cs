using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Identity
{
    public class ApplicationIdentityUser
    {
        public string Name { get; set; }
        public List<Group> Groups { get; set; }
    }
}
