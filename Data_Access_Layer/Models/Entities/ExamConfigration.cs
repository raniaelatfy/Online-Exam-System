using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Entities
{
   public class ExamConfigration
    {
        [Key]
        public int EconfigID { get; set; }
        public int Examtime { get; set; }
        public int QuestionNumber { get; set; }
    }
}
