using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories
{
    public class PresencaRepositoryEF : RepositoryBase<Presenca>, IPresencaRepository
    {
        public PresencaRepositoryEF(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

        public override void Delete(int id)
        {
            base.Delete(id);
        }
    }
}