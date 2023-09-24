
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
   public class TestStandardVM
   {
             
      public Int64 TestStandardID { get; set; }
      public string? TestStandardName { get; set; }
      public Int64 TestGroupAttributeID { get; set; }
      public Int64 TestNameID { get; set; }
      public string? TestName { get; set; }
      public Boolean? IsActive { get; set; }
      public Int64 Creator { get; set; }
      public DateTime? CreationDate { get; set; }
      public Int64? Modifier { get; set; }
      public DateTime? ModificationDate { get; set; }

   }
}
