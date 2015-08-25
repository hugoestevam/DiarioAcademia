using NDDigital.DiarioAcademia.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Aplicacao.Services
{
    public interface IService<T>
    {
        void Add(T obj);

        void Update(T obj);

        void Delete(int id);

        T GetById(int id);

        IList<T> GetAll();
    }

   //  public class GenericService<T> : IService<T>
   // {
   //     private IRepository<T> _repo;
   //
   //     public GenericService(IRepository<T> repo)
   //     {
   //         _repo = service;
   //     }
   //
   //     public void Add(T obj)
   //     {
   //         _repo.Add(obj);
   //     }
   //
   //     public void Delete(int id)
   //     {
   //         _repo.Delete(id);
   //     }
   //
   //     public IEnumerable<T> GetAll()
   //     {
   //         return _repo.GetAll();
   //     }
   //
   //     public T GetById(int id)
   //     {
   //         return _repo.GetById(id);
   //     }
   //
   //     public void Update(T obj)
   //     {
   //         _repo.Update(obj);
   //     }
   // }  TODO: nao deu liga
   //
}
