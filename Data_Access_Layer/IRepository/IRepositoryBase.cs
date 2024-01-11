using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public interface IRepositoryBase<T>
    {
       IEnumerable<T> GetAll();
        T GetById(object id);
        Task Insert(T obj);
        Task Edit(T obj);
        Task Delete(object id);
        Task Save();
    }
}
