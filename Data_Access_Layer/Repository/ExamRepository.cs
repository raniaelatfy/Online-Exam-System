using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Data_Access_Layer.IRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace RepositoryLayer.Data_Access_Layer.Repository
{
    public class ExamRepository : IExamRepository
    {
        ApplicationDbContext _repositoryContext;
        public ExamRepository(ApplicationDbContext repositoryContext) 
        {
            _repositoryContext = repositoryContext;

        }
        public async Task AddExamAsync(Exam exam)
        {
            _repositoryContext.AddAsync(exam);

            _repositoryContext.SaveChanges();
        }

      

        public async Task<List<Question>> RequestExamAsync(int subjectId)
        {
            var questions = await _repositoryContext.Questions.Where(n => n.SubjectID ==subjectId)
                .OrderBy(x => Guid.NewGuid()).Take(10)
                .Include(n =>n.Subjectquestion).Include(n=>n.QuestionChoices)
                .ToListAsync();
           
            return questions;
           
        }
    }
}
