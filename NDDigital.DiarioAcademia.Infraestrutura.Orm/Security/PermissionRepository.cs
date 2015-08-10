using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Security
{
    public interface IPermissionRepository
    {
        void Add(Permission permission);

        void Update(Permission permission);

        void Delete(Permission permission);

        IList<Permission> GetAll(Permission permission);

        Permission GetById(int id);
    }

    public class PermissionRepository : IPermissionRepository
    {
        public DiarioAcademiaContext _context;

        public PermissionRepository()
        {
            _context = new DiarioAcademiaContext();
        }

        public void Add(Permission permission)
        {
            try
            {
                _context.Permissions.Add(permission);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(Permission permission)
        {
            try
            {
                _context.Permissions.Remove(permission);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<Permission> GetAll(Permission permission)
        {
            try
            {
                return _context.Permissions.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Permission GetById(int id)
        {
            try
            {
                return _context.Permissions.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Permission permission)
        {
            if (permission != null)
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