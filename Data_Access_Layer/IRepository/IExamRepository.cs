using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data_Access_Layer.IRepository
{
    public interface IExamRepository
    {

    Task<List<Question>> RequestExamAsync(int subjectId);
    Task AddExamAsync(Exam exam);
   
    }
}
