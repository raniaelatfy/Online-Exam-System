using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Entities
{
    public class Student
    {
        public Student()
        {
            StudentExams = new HashSet<Exam>();
            StudentSubjects = new HashSet<Subject>();
            ExamHistory = new HashSet<ExamResult>();
        }

        [Key]
       
        public string StudentID { get; set; }
       
        [Required]
        [MinLength(3)]
        public string StudentFName { get; set; }
        [Required]
        [MinLength(3)]
        public string StudentLName { get; set; }

        [Required]
        [EmailAddress]
        public string StudentEmail { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Exam> StudentExams { get; set; }
        public virtual ICollection<Subject> StudentSubjects { get; set; }
        public virtual ICollection<ExamResult> ExamHistory { get; set; }
    
}
}
