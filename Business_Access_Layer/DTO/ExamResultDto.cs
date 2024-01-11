using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Bussiness_Logic_Layer.DTO
{
  public class ExamResultDto
    {
  
        
        public string subjectName { get; set; }
        public DateTime examDate { get; set; }
       
        public int examScore { get; set; }
    }
}
