using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Security
{
    public interface IGroupRepository : IRepository<Group>
    {
    }

    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        public GroupRepository(IDatabaseFactory dbFactory)
         : base(dbFactory)
        {
        }

        //public void Add(Group group)
        //{
        //    try
        //    {
        //        _context.Groups.Add(group);
        //        _context.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public void Delete(Group group)
        //{
        //    try
        //    {
        //        _context.Groups.Remove(group);
        //        _context.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public IList<Group> GetAll()
        //{
        //    try
        //    {
        //        return _context.Groups.ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public Group GetById(int id)
        //{
        //    try
        //    {
        //        return _context.Groups.Find(id);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public void Update(Group group)
        //{
        //    if (group != null)
        //    {
        //        try
        //        {
        //            _context.Entry(group).State = EntityState.Modified;
        //            _context.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            throw new Exception(e.Message);
        //        }
        //    }
        //}
    }
}