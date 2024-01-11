using ApplicationLayer.Bussiness_Logic_Layer.IServices;
using AutoMapper;
using Business_Access_Layer.ViewModels;
using Catel.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using System.Text;

namespace Exam_Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;

        public AuthenticateController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;


        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginModel)
        {
            var loginuser = await _authenticationService.Login(loginModel);

            return Ok(loginuser);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {

            await _authenticationService.Register(model);
            return Ok("User created successfully!");
        }
    }
}

