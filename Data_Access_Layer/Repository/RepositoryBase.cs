using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer.Repository.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
   public class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext RepositoryContext { get; set; }
        //private EmployeeDBContext _context = null;
        private DbSet<T> table;
        public RepositoryBase(ApplicationDbContext  repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
            table = RepositoryContext.Set<T>();
        }

        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);

        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

       
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            RepositoryContext.SaveChanges();
        }

        async Task IRepositoryBase<T>.Edit(T obj)
        {
            table.Attach(obj);
            RepositoryContext.Entry(obj).State = EntityState.Modified;
            RepositoryContext.SaveChanges();
        }

        Task IRepositoryBase<T>.Insert(T obj)
        {
            throw new NotImplementedException();
        }

        Task IRepositoryBase<T>.Delete(object id)
        {
            throw new NotImplementedException();
        }

        Task IRepositoryBase<T>.Save()
        {
            throw new NotImplementedException();
        }
    }
}

