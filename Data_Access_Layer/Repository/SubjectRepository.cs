using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer.Repository.Pagination;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Data_Access_Layer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data_Access_Layer.Repository
{
    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
       
        ApplicationDbContext _repositoryContext;
        public SubjectRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
           
        }
       

        public async Task AddSubjectAsync(Subject subject)
        {
            await _repositoryContext.AddAsync(subject);
            await _repositoryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectAsync(PagingParameters pagingParameters)
        {

            var subjects = _repositoryContext.Subjects.ToList();
            return  subjects.Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize).Take(pagingParameters.PageSize).ToList();
        }

        public async Task UpdateSubjectAsync( Subject subject)
        {
                  _repositoryContext.Update(subject);
            await _repositoryContext.SaveChangesAsync();
        }

       
    }
}
