using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Entities
{
    public class StudentSubject
    {
        [Key]
        public int StuSubjID  {get;set;}
        [ForeignKey("Student")]
        public string StudentID { get; set; }
       
        public virtual Student Student{ get; set; }
        [ForeignKey("Subject")]
        public int? SubjectID { get; set; }
       
        public virtual Subject Subject { get; set; }

    }
}
