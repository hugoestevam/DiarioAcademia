﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.IntegrationTests.EntityFramework
{
    [TestClass]
    public class AuthenticationTest
    {
        private static Permission alunoList = new Permission { PermissionId = "01" };
        private static Permission alunoEdit = new Permission { PermissionId = "02" };
        private static Permission alunoCreate = new Permission { PermissionId = "03" };

        public DiarioAcademiaContext _context = new DiarioAcademiaContext();

        private static List<Group> Groups = new List<Group>()
            {
                new Group
                {
                    Name = "Administrators",
                    Permissions = new List<Permission>
                    {
                        alunoList,
                        alunoEdit,
                        alunoCreate
                    },
                    IsAdmin = true
                },
                new Group
                {
                    Name = "Editor",
                    Permissions = new List<Permission>
                    {
                        alunoList,
                        alunoEdit,
                    }
                },
                new Group
                {
                    Name = "Viewr",
                    Permissions = new List<Permission>
                    {
                        alunoList,
                    }
                }
        };

        [TestMethod]
        public void Teste()
        {
            _context.SaveChanges();
        }
    }
}