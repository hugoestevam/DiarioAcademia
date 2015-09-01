using Infrasctructure.DAO.ORM.Contexts;
using Microsoft.AspNet.Identity;
using Moq;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using System.Data.Entity;

namespace NDDigital.DiarioAcademia.IntegrationTests.Base
{
	public class DatabaseTestInitializer : DropCreateDatabaseAlways<EntityFrameworkContext>
	{
		public EntityFrameworkContext _context;
		private readonly Mock<UserRepository> _userRepository = null;
		public IUserStore<User> _store;

		public const string SqlCleanDB = @"DBCC CHECKIDENT ('[TBPresenca]', RESEED, 0)
										   DBCC CHECKIDENT ('[TBAula]', RESEED, 0)
										   DBCC CHECKIDENT ('[TBAluno]', RESEED, 0)
										   DBCC CHECKIDENT ('[TBTurma]', RESEED, 0)
										   DBCC CHECKIDENT ('[TBGroup]', RESEED, 0)
										   DBCC CHECKIDENT ('[TBAccount]', RESEED, 0)
										   DBCC CHECKIDENT ('[TBPermission]', RESEED, 0)

										   DELETE FROM TBAccountGroups
										   DELETE FROM TBGroupPermission
										   DELETE FROM TBPresenca
										   DELETE FROM TBAula
										   DELETE FROM TBAluno
										   DELETE FROM TBTurma
										   DELETE FROM TBUser
										   DELETE FROM TBAccount
										   DELETE FROM TBGroup
										   DELETE FROM TBPermission";
		public DatabaseTestInitializer()
		{
			_userRepository = new Mock<UserRepository>();

			_context = new EntityFrameworkContext();

			_context.Database.ExecuteSqlCommand(SqlCleanDB);
			_context.SaveChanges();

			Seed(_context);
		}

		protected override void Seed(EntityFrameworkContext context)
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

			context.Set<User>().Add(ObjectBuilder.CreateUser());
			context.SaveChanges();

		}
	}
}