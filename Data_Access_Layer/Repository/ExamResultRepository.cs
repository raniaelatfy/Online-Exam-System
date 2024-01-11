using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer.Repository.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Data_Access_Layer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data_Access_Layer.Repository
{
    public class ExamResultRepository : RepositoryBase<ExamResult>, IExamResultRepository
    {
        private readonly ApplicationDbContext _repositoryContext;

        public ExamResultRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<List<ExamResult>> GetAllExamHistoryAsync(PagingParameters pagingParameters)
        {
            var examresults =await _repositoryContext.ExamResults
                     .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                     .Take(pagingParameters.PageSize)
                     .Include(n=>n.StudentResult.ExamHistory)
                     .Include(n => n.SubjectResult)
                     .Include(n => n.ResultExam)
                     .ToListAsync();
            return examresults;
        }

        public async Task<List<ExamResult>> GetAllExamResultAsync(PagingParameters pagingParameters,string studentid)
        {
           
           var examresults =await _repositoryContext.ExamResults.Where(n => n.StudentID == studentid)
                    .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                    .Take(pagingParameters.PageSize).Include(n => n.SubjectResult).Include(n => n.ResultExam).ToListAsync();
                return examresults;
        }

       
    }
}
