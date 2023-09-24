using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.Models.Request
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
   public class LoginUser
    {
      public Int64 ID { get; set; }
      public string? Name { get; set; }
      public string? UserName { get; set; }
      public string? Email { get; set; }
      public string? Designation { get; set; }
      public string? Password { get; set; }
      public Int64 UserTypeAttributeID { get; set; } = 1;
      public string? UserTypeAttributeName { get; set; }
      public Int64 UserSectionID { get; set; } = 1;
      public string? UserSectionName { get; set; }
      public bool? IsActive { get; set; }
      public Int64 Creator { get; set; } = 1;
      public DateTime? CreationDate { get; set; } 
      public Int64? Modifier { get; set; }
      public DateTime? ModificationDate { get; set; }

   }
    public class authenticuserdata
    {
        public Int64 id { get; set; }
        public string name { get; set; }
        public Int64 usertype { get; set; }
        public string token { get; set; }
        public int statuscode { get; set; }
        public string statusmessage { get; set; }
    }
}
