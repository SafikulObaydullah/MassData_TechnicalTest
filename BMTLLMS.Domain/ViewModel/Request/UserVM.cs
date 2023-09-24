using BMTLLMS.Domain.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
   public class UserVM
   {
      public Int64 ID { get; set; }
      public string Name { get; set; }
      public string? UserName { get; set; }
      public string? Email { get; set; }
      public string? Designation { get; set; }
      public string? Password { get; set; }
      public Int64 UserTypeAttributeID { get; set; }
      public string? UserTypeAttributeName { get; set; }
      public Int64 UserSectionID { get; set; }
      public string? UserSectionName { get; set; }
      public Boolean? IsActive { get; set; }
      public Int64 Creator { get; set; }
      public DateTime? CreationDate { get; set; }
      public Int64? Modifier { get; set; }
      public DateTime? ModificationDate { get; set; }

   }
}
