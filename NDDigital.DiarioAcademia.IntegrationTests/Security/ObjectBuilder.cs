using FizzWare.NBuilder;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using System;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.SecurityTests
{
    public class ObjectBuilder
    {
        private static User CreateUser()
        {
            return new User { FirstName = "thiago", JoinDate = DateTime.Now, LastName = "sartor", Level = 2, Groups = CreateListGroups() };
        }

        private static Group CreateGroup()
        {
            return new Group { Name = "Administrador", IsAdmin = true, Permissions = CreateListPermissions() };
        }

        private static Permission CreatePermission()
        {
            return new Permission { PermissionId = "01" };
        }

        private static List<Permission> CreateListPermissions()
        {
            return new List<Permission>
            {
                new Permission { PermissionId = "01" },
                new Permission { PermissionId = "02" }
            };
        }

        private static List<Group> CreateListGroups()
        {
            return new List<Group>
            {
                 new Group { Name = "Administrador", IsAdmin = true, Permissions = CreateListPermissions() },
                 new Group { Name = "Editores", IsAdmin = false, Permissions = CreateListPermissions() }
            };
        }
    }
}