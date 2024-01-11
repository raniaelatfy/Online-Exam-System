
using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer.Repository.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
      Task<IEnumerable<Student>> GetAllStudent(PagingParameters pagingParameters);
      Task changeStatus(Student  studentStatus);
      Task<IEnumerable<StudentSubject>> GetAllStudentSubjectsAsync(string studentid, PagingParameters pagingParameters);
      Task<IEnumerable<Student>> GetAllStudentexamhistoryAsync(string studentid, PagingParameters pagingParameters);

    }


}
