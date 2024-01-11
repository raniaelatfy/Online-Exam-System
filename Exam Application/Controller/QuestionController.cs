using ApplicationLayer.Bussiness_Logic_Layer.DTO;
using ApplicationLayer.Bussiness_Logic_Layer.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionService _questionService;

        public QuestionController(QuestionService questionService)
        {
            _questionService = questionService;
        }
        [Route("AddQuestion")]
        [HttpPost]
        public async Task<ActionResult> AddQuestion(QuestionDto questionDto)
        {
            await _questionService.AddQuestion(questionDto);
            
            return Ok("Question Added Successfully");

        }

    }
}
