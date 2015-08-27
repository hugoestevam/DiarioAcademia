using NDDigital.DiarioAcademia.Dominio.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Dominio.Entities.Security
{
    public class Account : Entity
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        public List<Group> Groups { get; set; }

        public Account(string username)
        {
            Username = username;
        }

    }
}
