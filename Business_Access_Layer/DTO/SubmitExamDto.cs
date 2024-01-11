using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Bussiness_Logic_Layer.DTO
{
    public class SubmitExamDto
    {

        public string StudentId { get; set; }
        public List<ExamQuestionDto> ExamQuestions{ get; set; }
    }
}
