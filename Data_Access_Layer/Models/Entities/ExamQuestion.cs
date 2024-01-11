using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Entities
{
    public class ExamQuestion
    {
        [Key]
       public int EQuestionID { get; set; }
        [ForeignKey("ExamQuestions")]
        public int? ExamID { get; set; }
        public virtual Exam ExamQuestions { get; set; }
        [ForeignKey("QuestionExam ")]
        public int? QuestionID { get; set; }
        public virtual Question QuestionExam { get; set; }

    }
}

