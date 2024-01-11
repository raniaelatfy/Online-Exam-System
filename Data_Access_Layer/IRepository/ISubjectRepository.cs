
using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer.Repository.Pagination;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data_Access_Layer.IRepository
{
    public interface ISubjectRepository : IRepositoryBase<Subject>
    {

        Task<IEnumerable<Subject>> GetAllSubjectAsync(PagingParameters pagingParameters);
        Task UpdateSubjectAsync(Subject subject);
        Task AddSubjectAsync(Subject subject);
    }
}
