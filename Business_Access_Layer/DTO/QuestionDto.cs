using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Bussiness_Logic_Layer.DTO
{
    public class QuestionDto
    {
        public int SubjectID { get; set; }
        public string QuestionName { get; set; }

        public List<AddChoicesDto> QuestionChoices { get; set; } 

       

    }
}
