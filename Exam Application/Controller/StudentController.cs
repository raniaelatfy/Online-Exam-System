using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using Business_Access_Layer.ViewModels;
using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Pagination;
using Data_Access_Layer.Repository.Entities;
using Microsoft.VisualStudio.Services.WebApi;
using ApplicationLayer.DTO;

using Business_Access_Layer;
using Microsoft.AspNetCore.Authorization;

namespace Exam_Application.Controller
{
    [Route("api")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly  StudentServices StudentService;
        public StudentController(IMapper mapper, IStudentRepository StudentRepository, StudentServices StudentService)
        {
            this.StudentService = StudentService;
        }

        [Route("AllStudent")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllStudent([FromQuery] PagingParameters pagingParameters)
        {


            var students = await StudentService.GetAllStudent(pagingParameters);


            return Ok(students);


        }
        [Route("changestatus")]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Changestatus(string studentId,bool IsActive)
        {
            await StudentService.Changestatus(studentId,IsActive);
            return Ok("updated");



        }


        //[HttpPost]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetStudentSubjects(string Id, [FromQuery] PagingParameters pagingParameters)
        {
            var studentSubjects = await StudentService.GetStudentSubjects(Id, pagingParameters);
            return Ok(studentSubjects);
        }

        //[HttpDelete]
        [HttpGet]
        [Route("ExamHistory")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetStudentExamHistory([FromHeader] string Id, [FromQuery] PagingParameters pagingParameters)
        {
            var ExamHistory = await StudentService.GetStudentExamHistory(Id, pagingParameters);
            return Ok(ExamHistory);
        }
    }
}

