using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Bussiness_Logic_Layer.DTO
{
   public class IdentityDto
    {
       public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string roleName { get; set; }

    }
}
