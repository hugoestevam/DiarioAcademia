using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Factorys;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Modules;
using NDDigital.DiarioAcademia.Infraestrutura.SQL.Common;
using NDDigital.DiarioAcademia.Infraestrutura.SQL.Modules;
using NDDigital.DiarioAcademia.Infraestrutura.SQL.Repositories;
using Ninject;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace NDDigital.DiarioAcademia.Infraestrutura.IoC
{
    public static class Container
    {
        private static IKernel _container;

        public static T Get<T>()
        {
            return _container.TryGet<T>();
        }

        static Container()
        {
            ConfigContainer();
        }

        private static void ConfigContainer()
        {
            _container = new StandardKernel();         


            string path
                   = new FileInfo(
                                Assembly
                                .GetExecutingAssembly()
                                .Location)
                                .DirectoryName;

            string fileName
                    = ConfigurationSettings.AppSettings["Infrasctructure.DAO"];


            string assemblyFile
                    = string.Format("{0}\\{1}", path, fileName);

            Assembly file = Assembly.LoadFrom(assemblyFile);

            _container.Load(file);
        }
    }
}