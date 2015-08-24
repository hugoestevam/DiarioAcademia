

using NDDigital.DiarioAcademia.Infraestrutura.SQL.Repositories;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using Ninject.Modules;

namespace NDDigital.DiarioAcademia.Infraestrutura.SQL.Modules
{
    public class AdoNetNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITurmaRepository>().To<TurmaRepositorySql>();
            Bind<IAulaRepository>().To<AulaRepositorySql>();
            Bind<IAlunoRepository>().To<AlunoRepositorySql>();
            Bind<IPresencaRepository>().To<PresencaRepositorySql>();
        }
    }
}