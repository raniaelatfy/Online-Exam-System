using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Entities
{
    public class Subject
    {
        public Subject()
        {
            SubjectStudents = new HashSet<Student>();
            SubjectExams = new HashSet<Exam>();
            SubjectQuestions = new HashSet<Question>();
        }
        [Key]
        public int SubjectID { get; set; }
        [Required]
        public string SubjectName { get; set; }

        public virtual ICollection<Question> SubjectQuestions { get; set; }
        public virtual ICollection<Student> SubjectStudents { get; set; }
        public virtual ICollection<Exam> SubjectExams { get; set; }


    }
}
