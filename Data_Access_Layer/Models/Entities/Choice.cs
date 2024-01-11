using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Entities
{
   public class Choice
    {
        [Key]
        public int ChoiceID { get; set; }
        public string ChoiceName { get; set; }
        [ForeignKey("Question")]
        public int? QuestionID { get; set; }
        public bool IsCorrect{ get; set; }
        public virtual Question Question { get; set; }
        
    }
}
