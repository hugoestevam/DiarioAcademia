using FizzWare.NBuilder.Implementation;
using Microsoft.AspNet.Identity;
using Moq;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using NDDigital.DiarioAcademia.IntegrationTests.Security;
using NDDigital.DiarioAcademia.SecurityTests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.IntegrationTests.Base
{
    public class BaseTest : DropCreateDatabaseAlways<DiarioAcademiaContext>
    {
        public DiarioAcademiaContext _context;
        private readonly Mock<UserRepository> _userRepository = null;
        public IUserStore<User> _store;
        public const string SqlCleanDB = @"DBCC CHECKIDENT ('[TBPresenca]', RESEED, 0)
                                           DBCC CHECKIDENT ('[TBAula]', RESEED, 0)
                                           DBCC CHECKIDENT ('[TBAluno]', RESEED, 0)
                                           DBCC CHECKIDENT ('[TBTurma]', RESEED, 0)
                                           DBCC CHECKIDENT ('[TBGroup]', RESEED, 0)
                                           DBCC CHECKIDENT ('[TBPermission]', RESEED, 0)

                                           DELETE FROM TBPresenca
                                           DELETE FROM TBAula
                                           DELETE FROM TBAluno
                                           DELETE FROM TBTurma
                                           DELETE FROM TBUserGroups
                                           DELETE FROM TBGroupPermission
                                           DELETE FROM TBGroup
                                           DELETE FROM TBPermission
										   DELETE FROM TBUser";

        public BaseTest()
        {
           Db.Update(SqlCleanDB);

            _userRepository = new Mock<UserRepository>();         

            _context = new DiarioAcademiaContext();

            Seed(_context);
        }

        protected override void Seed(DiarioAcademiaContext context)
        {
            base.Seed(context);

            //Adiciona uma turma
            context.Set<Turma>().Add(ObjectBuilder.CreateTurma());
            context.SaveChanges();

            //Busca a turma do id = 1
            var turmEncontrada = context.Set<Turma>().Find(1);

            //Adiciona um aluno
            context.Set<Aluno>().Add(ObjectBuilder.CreateAluno(turmEncontrada));
            context.SaveChanges();

            //Busca aluno do id = 1
            var alunoEncontrado = context.Set<Aluno>().Find(1);

            //Adiciona uma aula
            context.Set<Aula>().Add(ObjectBuilder.CreateAula(turmEncontrada));
            context.SaveChanges();

            //Adiciona uma permissao
            context.Set<Permission>().Add(ObjectBuilder.CreatePermission());
            context.SaveChanges();

            var otherPermission = ObjectBuilder.CreatePermission();
            otherPermission.PermissionId = "02";

            //Adiciona outra permissao
            context.Set<Permission>().Add(otherPermission);
            context.SaveChanges();

            //Busca permissioes
            var listPermissions = context.Set<Permission>().ToList();

            //Adiciona lista de permissoes no grupo
            var group = ObjectBuilder.CreateGroup();
            group.Permissions = listPermissions;

            //Adiciona um group
            context.Set<Group>().Add(group);
            context.SaveChanges();

            var otherGroup = ObjectBuilder.CreateGroup();

            group.Name = "Editor";

            //Adiciona outro group
            context.Set<Group>().Add(group);
            context.SaveChanges();

            //Busca permissioes
            var listGroups = context.Set<Group>().ToList();

            //Adiciona lista de grupos
            var user = ObjectBuilder.CreateUser();
            user.Groups = listGroups;
            var password = "123456";

            //Adiciona um usuário
            _userRepository
            .Setup(x => x.CreateAsync(user, password));
        }
    }
}
