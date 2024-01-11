using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Data_Access_Layer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data_Access_Layer.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        ApplicationDbContext _repositoryContext;
        public QuestionRepository(ApplicationDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

        }

        public async Task AddQuestionAsync(Question question)
        {
            await _repositoryContext.AddAsync(question);
         

            await _repositoryContext.SaveChangesAsync();
        }
        public async Task AddChoiceAsync( List<Choice> choices)
        {
         
            await _repositoryContext.AddAsync(choices);

            await _repositoryContext.SaveChangesAsync();
        }

        public async Task<Question> GetQuestionAsync(int id)
        {
            return await _repositoryContext.Questions.FindAsync(id);
        }
        public async Task<Choice> GetRightChoiceAsync(int questionId)
        {
            return await _repositoryContext.Choices.Where(n => n.QuestionID == questionId && n.IsCorrect == true).FirstOrDefaultAsync();
        }
    }
}
