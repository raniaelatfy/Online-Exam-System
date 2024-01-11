using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationLayer.Bussiness_Logic_Layer.DTO
{
   public class ExamQuestionDto
    {
        
        public int QuestionId { get; set; }
      
        public int ChoiceId { get; set; } 
      

    }
}
