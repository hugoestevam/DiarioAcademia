using NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts;
using System;


namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Common
{
    public interface IDatabaseFactory : IDisposable
    {
        DiarioAcademiaContext Get();
    }
}