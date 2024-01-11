using AutoMapper;
using Azure;
using Azure.Core;
using Business_Access_Layer.ViewModels;
using Data_Access_Layer;
using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer.Repository.Pagination;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.TestManagement.TestPlanning.WebApi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Linq.Dynamic.Core;
using ApplicationLayer.DTO;
using ApplicationLayer.Bussiness_Logic_Layer.DTO;

namespace Business_Access_Layer
{
    public class StudentServices
    {
        private IMapper mapper;
        public readonly IStudentRepository _studentrepository;
        ApplicationDbContext _Context;
        public StudentServices(IStudentRepository studentrepository, IMapper mapper, ApplicationDbContext Context)
        {
            _studentrepository = studentrepository;
            this.mapper = mapper;
            _Context = Context;
        }


        public async Task<IEnumerable<StudentDTO>> GetAllStudent(PagingParameters pagingParameters)
        {

            var studentslist = await _studentrepository.GetAllStudent(pagingParameters);

            return mapper.Map<IEnumerable<Student>, IEnumerable<StudentDTO>>(studentslist);


        }

        public async Task Changestatus(string studentId, bool IsActive)
        {
                var studentstatus = _studentrepository.GetById(studentId);
                if (studentstatus is null)
                {

                    throw new Exception($"student with Id {studentId} is InValid");
                }
                studentstatus.IsActive = IsActive;
                await _studentrepository.changeStatus(studentstatus);


            
        }
       
    
        public async Task<IEnumerable< StudentSubjectDto>> GetStudentSubjects(string Id, PagingParameters pagingParameters)
        {
        
            var studentsubjectslist = await _studentrepository.GetAllStudentSubjectsAsync( Id, pagingParameters);

            return mapper.Map<IEnumerable<StudentSubject> ,IEnumerable<StudentSubjectDto>>(studentsubjectslist);


        }

        public async Task<IEnumerable<StudentDTO>> GetStudentExamHistory(string Id, PagingParameters pagingParameters)
        {

            var studentexamhistorylist = await _studentrepository.GetAllStudentexamhistoryAsync(Id, pagingParameters);

            return mapper.Map<IEnumerable<Student>, IEnumerable<StudentDTO>>(studentexamhistorylist);


        }


    }

}
           


 
