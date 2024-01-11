using ApplicationLayer.Bussiness_Logic_Layer.DTO;
using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Bussiness_Logic_Layer.IServices
{
    public class DashboardService
    {
        ApplicationDbContext _Context;
        public DashboardService(ApplicationDbContext Context)
        {
            _Context = Context;

        }

        public  DashboardDto GetDashboardData()
        {
            DashboardDto dashboardDto = new DashboardDto();
            dashboardDto.StudentNumbers = _Context.Students.Where(n => n.IsActive == true).Count();
            dashboardDto.ExamsCompleted = _Context.ExamResults.Count();
            dashboardDto.PassedExamsNumber = _Context.ExamResults.Where(n => n.Score>5).Count();
            dashboardDto.FailedExamsNumber = _Context.ExamResults.Where(n => n.Score < 5).Count();
            return dashboardDto;


        }
    }
}
