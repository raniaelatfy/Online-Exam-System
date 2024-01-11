using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationLayer.Bussiness_Logic_Layer.DTO;
using Data_Access_Layer.Repository.Pagination;
using ApplicationLayer.Bussiness_Logic_Layer.IServices;
using Microsoft.AspNetCore.Authorization;

namespace Exam_Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
      
        private readonly SubjectService _subjectService;

        public SubjectController(SubjectService subjectService)
        {
           
         
            _subjectService = subjectService;
        }
        [Route("GetAllsubject")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllSubjectAsync([FromQuery] PagingParameters pagingParameters)
        {


            var subjects = await _subjectService.GetAllSubjectAsync(pagingParameters);


            return Ok(subjects);


        }
        [Route("updatesubject")]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateSubject(SubjectDto subjectDto)
        {


            await _subjectService.UpdateSubject(subjectDto);


            return Ok("updated");


        }

        [Route("AddSubject")]
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> AddNewSubject(AddSubjectDto subjectDto)
        {
           await _subjectService.AddNewSubject(subjectDto);
            return Ok("Added");
        }
    }
}
