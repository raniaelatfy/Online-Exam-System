using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Entities
{
    public class Question
    {

        public Question()
        {
            QuestionExams = new HashSet<Exam>();
            QuestionChoices = new HashSet<Choice>();

        }
        [Key]
        public int QuestionID { get; set; }
        public string QuestionName { get; set; }
        [ForeignKey("Subjectquestion")]
        public int SubjectID { get; set; }
        public virtual Subject Subjectquestion { get; set; }
        public virtual ICollection<Exam> QuestionExams { get; set; }
        public virtual ICollection<Choice> QuestionChoices { get; set; }

    }
}
