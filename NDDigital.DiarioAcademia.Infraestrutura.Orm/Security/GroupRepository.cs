using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Security
{
    public interface IGroupRepository
    {
        void Add(Group group);

        void Update(Group group);

        void Delete(Group group);

        IList<Group> GetAll(Group group);

        Group GetById(int id);
    }

    public class GroupRepository : IGroupRepository
    {
        public DiarioAcademiaContext _context;

        public GroupRepository()
        {
            _context = new DiarioAcademiaContext();
        }

        public void Add(Group group)
        {
            try
            {
                _context.Groups.Add(group);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(Group group)
        {
            try
            {
                _context.Groups.Remove(group);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<Group> GetAll(Group group)
        {
            try
            {
                return _context.Groups.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Group GetById(int id)
        {
            try
            {
                return _context.Groups.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Group group)
        {
            if (group != null)
            {
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
}