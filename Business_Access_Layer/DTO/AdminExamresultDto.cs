using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Bussiness_Logic_Layer.DTO
{
    public class AdminExamresultDto
    {
        public string SubjectName { get; set; }
        public string StudentName { get; set; }
        public DateTime ExamDate { get; set; }

        public int ExamScore { get; set; }
    }
}
