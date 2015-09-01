using Ninject;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace NDDigital.DiarioAcademia.Infraestrutura.IoC
{
    public static class Injection
    {
        private static IKernel _container;

        public static T Get<T>()
        {
            return _container.TryGet<T>();
        }

        static Injection()
        {
            ConfigContainer();
        }

        private static void ConfigContainer()
        {
            _container = new StandardKernel();

            string path
                   = Path.GetDirectoryName(
                       Assembly.GetExecutingAssembly()
                       .GetName()
                       .CodeBase);

            path = path.Substring(6, path.Length - 6);

            string fileName
                    = ConfigurationSettings.AppSettings["Infrasctructure.DAO"];


            string assemblyFile
                    = string.Format("{0}\\{1}", path, fileName);

            Assembly file = Assembly.LoadFrom(assemblyFile);

            _container.Load(file);
        }
    }
}