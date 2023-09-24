
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
   public class MachineVM
   {
     public Int64 ID { get; set; } 
      public string Name { get; set; }
      public string? JawType { get; set; }
      public Int64 MachineTypeAttributeID { get; set; }
      public string? AttributeName { get; set; }
      public Boolean? IsActive { get; set; }
      public Int64 Creator { get; set; }
      public DateTime? CreationDate { get; set; }
      public Int64? Modifier { get; set; }
      public DateTime? ModificationDate { get; set; }

   }
}
