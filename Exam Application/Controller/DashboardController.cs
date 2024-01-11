using ApplicationLayer.Bussiness_Logic_Layer.DTO;
using ApplicationLayer.Bussiness_Logic_Layer.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Data_Access_Layer.IRepository;

namespace Exam_Application.Controller
{
    [Route("api/Dashboard")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardService _dashboardService;
        public DashboardController(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
                
        }
        [Route("GetDashboardData")]
        [HttpGet]
        public DashboardDto GetDashboardData()
        {
            var DashboardData = _dashboardService.GetDashboardData();

            return DashboardData;
        }
    }
}
