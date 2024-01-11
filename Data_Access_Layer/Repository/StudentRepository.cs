using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer.Repository.Pagination;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.SqlServer.Server;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;

namespace Data_Access_Layer.Repository
{
    public class StudentRepository : RepositoryBase<Student> ,IStudentRepository
    {
        private readonly IMapper _mapper;
        ApplicationDbContext _repositoryContext;
        private readonly UserManager<ApplicationUser> _userManager;
         public StudentRepository(ApplicationDbContext repositoryContext,IMapper mapper, UserManager<ApplicationUser> userManager) : base(repositoryContext)
        {
           _repositoryContext = repositoryContext;
            _mapper = mapper;
            _userManager=userManager ??throw new ArgumentNullException(nameof(userManager));
        }





        public async Task<IEnumerable<Student>> GetAllStudent(PagingParameters pagingParameters)
        {
            var students = await _repositoryContext.Students.ToListAsync();
            return  students
                .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                .Take(pagingParameters.PageSize)
                .ToList();
            //return Task.FromResult(PagedList<ApplicationUser>.CreateAsync(
            //FindAll().OrderBy(s => s.StudentID), pagingParameters.PageNumber, pagingParameters.PageSize));
        }

        //    public async Task<PagedList<ApplicationUser>> GetAllStudent(PagingParameters pagingParameters)
        //{

        //      var students = await _userManager.GetUsersInRoleAsync("Student");
        //    var query = students.AsQueryable();
        //    return await PagedList<ApplicationUser>.CreateAsync(
        //    query.ProjectTo<ApplicationUser>(_mapper.ConfigurationProvider).AsNoTracking(), pagingParameters.PageNumber, pagingParameters.PageSize);
        //}

        public async Task changeStatus(Student studentStatus)
        {
          _repositoryContext.Update(studentStatus);
         await _repositoryContext.SaveChangesAsync();
           
        }

        public async Task<IEnumerable<StudentSubject>> GetAllStudentSubjectsAsync(string studentid, PagingParameters pagingParameters)
        {
            var studentSubjectsList = _repositoryContext.StudentSubjects.Where(n => n.StudentID == studentid).Include(n => n.Subject);
            return await studentSubjectsList.Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                .Take(pagingParameters.PageSize)
                .ToListAsync();
        }

       
        public async Task<IEnumerable<Student>> GetAllStudentexamhistoryAsync(string studentid, PagingParameters pagingParameters)
        {
            var studentexamhistoryList = _repositoryContext.Students.Where(n => n.StudentID == studentid).Include(n => n.ExamHistory);
            return await studentexamhistoryList
                .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                .Take(pagingParameters.PageSize)
                .ToListAsync();
        }

    }
}
