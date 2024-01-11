using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer.Repository.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data_Access_Layer.IRepository
{
    public interface IExamResultRepository:IRepositoryBase<ExamResult>
    {
        Task<List<ExamResult>> GetAllExamResultAsync(PagingParameters pagingParameters,string studentid);
        Task<List<ExamResult>> GetAllExamHistoryAsync(PagingParameters pagingParameters);

    }
}
