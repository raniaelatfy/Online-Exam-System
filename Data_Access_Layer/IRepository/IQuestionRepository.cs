using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data_Access_Layer.IRepository
{
    public interface IQuestionRepository
    {
       Task AddQuestionAsync(Question question);
       Task<Question> GetQuestionAsync(int id);
        Task AddChoiceAsync(List<Choice>choices);
        Task<Choice> GetRightChoiceAsync(int questionId);

    }
}
