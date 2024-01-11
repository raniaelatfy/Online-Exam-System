using ApplicationLayer.Bussiness_Logic_Layer.DTO;
using ApplicationLayer.Bussiness_Logic_Layer.IServices;
using Data_Access_Layer.Repository.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Exam_Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ExamResultController : ControllerBase
    {
        private readonly ExamResultService _examResultService;
        public ExamResultController(ExamResultService examResultService)
        {
            _examResultService = examResultService;
        }

        [Route("GetAllExamResult")]
        [HttpGet]
        //[Authorize(Roles = "Student")]
        public async Task<ActionResult> GetAllExamResult([FromQuery]PagingParameters pagingParameters,string studentid)
        {
            var examresults = await _examResultService.GetAllExamResult(pagingParameters,studentid);
            return Ok( examresults);
        }
        [Route("AdminExamResult")]
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetAllExamHistory([FromQuery] PagingParameters pagingParameters)
        {
            var examresults = await _examResultService.GetAllExamHistory(pagingParameters);
            return Ok(examresults);
        }
    }
}
