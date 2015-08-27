using FizzWare.NBuilder;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;

namespace NDDigital.DiarioAcademia.IntegrantionTests.Base
{
    public class ObjectBuilder
    {
        public static Turma CreateTurma()
        {
            return Builder<Turma>.CreateNew()
            .WithConstructor(() =>
            new Turma(2014)).Build();
        }

        public static Aluno CreateAluno(Turma turma)
        {
            return Builder<Aluno>.CreateNew()
            .WithConstructor(() =>
            new Aluno("Thiago Sartor", turma)).Build();
        }

        private static Endereco CreateEndereco()
        {
            return Builder<Endereco>.CreateNew()
            .WithConstructor(() =>
            new Endereco("88509720",
            "Ferrovia",
            "Lages",
            "SC")).Build();
        }

        public static Aula CreateAula(Turma turma)
        {
            return Builder<Aula>.CreateNew()
            .WithConstructor(() =>
            new Aula(DateTime.Now, turma)).Build();
        }

        public static User CreateUser()
        {
            return null;// new User { FirstName = "thiago", LastName = "sartor",  UserName = "ttt" };
        }
        public static Account CreateAccount()
        {
            return null;// new User { FirstName = "thiago", LastName = "sartor",  UserName = "ttt" };
        }

        public static Group CreateGroup()
        {
            return null;// new Group { Name = "Administrador", IsAdmin = true, Permissions = CreateListPermissions() };
        }

        public static Permission CreatePermission()
        {
            return null;// new Permission { PermissionId = "01" };
        }

        public static List<Permission> CreateListPermissions()
        {
            return null;// new List<Permission>
       //     {
       //         new Permission { PermissionId = "01" },
       //         new Permission { PermissionId = "02" }
       //     };
        }

        public static List<Group> CreateListGroups()
        {
            return null;//new List<Group>
                        //   {
                        //        new Group { Name = "Administrador", IsAdmin = true, Permissions = CreateListPermissions() },
                        //        new Group { Name = "Editores", IsAdmin = false, Permissions = CreateListPermissions() }
                        //   };
        }
    }  
}