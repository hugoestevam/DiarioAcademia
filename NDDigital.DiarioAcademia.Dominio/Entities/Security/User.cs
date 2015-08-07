using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NDDigital.DiarioAcademia.Dominio.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Dominio.Entities.Security
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public byte Level { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }

        public List<Group> Groups { get; set; }

        public User()
        {
            EmailConfirmed = true;           
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            return userIdentity;
        }
    }
}