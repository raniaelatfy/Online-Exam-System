using ApplicationLayer.Bussiness_Logic_Layer.DTO;
using ApplicationLayer.Bussiness_Logic_Layer.IServices;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Exam_Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Student")]
    public class ExamController : ControllerBase
    {
        private readonly ExamService _examService;

        public ExamController(ExamService examService)
        {
            _examService = examService;

        }

        [Route("RequestExam")]
        [HttpGet]
        public async Task<IActionResult> RequestExam(int subjectId)
        {
            var Exam = await _examService.RequestExam(subjectId);
            return Ok(Exam);

        }

        [Route("submitExam")]
        [HttpPost]
        
        public async Task<ActionResult> SubmitExam(List<SubmitExamDto> examDto)
        {
            
            await _examService.SubmitExam(examDto);
            return Ok("Exam Submitted Successfully");

        }
    }
}
