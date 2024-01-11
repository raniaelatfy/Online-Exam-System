using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Access_Layer.ViewModels
{
   public class RegisterDTO
    {
      

        public string StudentFName { get; set; }
        
        public string StudentLName { get; set; }

        [Required]
       [EmailAddress]
        public string? Email { get; set; }
       [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
       [Required]
        
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
      

    }
}
