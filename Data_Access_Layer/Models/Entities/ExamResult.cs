using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Entities
{
   public class ExamResult
    {
        [Key]
        public int ExamResultID { get; set; }
        public int Score { get; set; }
        [ForeignKey("StudentResult")]
        public string StudentID { get; set; }
       
        public virtual Student StudentResult { get; set; }
        [ForeignKey("ResultExam ")]
        public int? ExamID { get; set; }
       
        public virtual Exam ResultExam { get; set; }
        [ForeignKey("SubjectResult")]
        public int? SubjectID { get; set; }
      
        public virtual Subject SubjectResult { get; set; }
    }
}
