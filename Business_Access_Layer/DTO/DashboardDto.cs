using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Bussiness_Logic_Layer.DTO
{
    public class DashboardDto
    {
        public int StudentNumbers { get; set; }
        public int ExamsCompleted { get; set; }
        public int PassedExamsNumber { get; set; }
        public int FailedExamsNumber { get; set; }
    }
}
