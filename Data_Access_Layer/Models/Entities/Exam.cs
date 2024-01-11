using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Entities
{
   public class Exam
    {
        public Exam()
        {
            ExamQuestions = new HashSet<Question>();
           
        }
        [Key]
        public int ExamID { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public int FullMark { get; set; } = 10;
        public int PassedMark { get; set; } = 5;
        [ForeignKey("Student")]
        public string StudentID { get; set; }
        
        public virtual Student Student { get; set; }
        [ForeignKey("Subject")]
        public int? SubjectID { get; set; }
       
        public virtual Subject Subject { get; set; }
        public virtual ICollection<Question> ExamQuestions { get; set; }

    }
}
