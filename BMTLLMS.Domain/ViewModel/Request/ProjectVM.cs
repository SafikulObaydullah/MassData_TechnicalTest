using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
   public class ProjectVM
   {
      public Int64 ID { get; set; }
      public string Name { get; set; }
      public string? contactPerson { get; set; }
      public string? contactPhone { get; set; }
      public string? contactEmail { get; set; }
      public Boolean? IsActive { get; set; }
      public Int64 Creator { get; set; }
      public DateTime? CreationDate { get; set; }
      public Int64? Modifier { get; set; }
      public DateTime? ModificationDate { get; set; }

   }
}
