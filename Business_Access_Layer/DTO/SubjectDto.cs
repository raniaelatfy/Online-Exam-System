using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Bussiness_Logic_Layer.DTO
{
    public class SubjectDto
    {


        [Key]
        public int SubjectID { get; set; }
        [Required]
        public string SubjectName { get; set; }

    }
}
