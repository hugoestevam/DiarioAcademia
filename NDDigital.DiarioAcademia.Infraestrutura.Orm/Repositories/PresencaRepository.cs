using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories
{
    public class PresencaRepository : RepositoryBase<Presenca>, IPresencaRepository
    {
        public PresencaRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

        public override void Delete(int id)
        {
            base.Delete(id);
        }
    }
}