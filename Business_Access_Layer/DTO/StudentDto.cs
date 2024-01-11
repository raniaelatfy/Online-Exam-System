using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Access_Layer.ViewModels
{
   public class StudentDTO
    {

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

       
    }
}
