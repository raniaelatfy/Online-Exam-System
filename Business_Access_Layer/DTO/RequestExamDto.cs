using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Bussiness_Logic_Layer.DTO
{
   public class RequestExamDto
    {
        public string QuestionName { get; set; }
        public List<RequestExamChoiceDto> QuestionChoices { get; set; }
     
    }
}
