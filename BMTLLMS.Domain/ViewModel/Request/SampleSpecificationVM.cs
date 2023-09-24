using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
    public class SampleSpecificationVM
   {
      public Int64 ID { get; set; }
      public string? SampleID { get; set; }
      public Int64 SpecificationID { get; set; }
      public List<SpecificationValueVM> Specifications { get; set; }
      public Boolean? IsActive { get; set; }
      public Int64 Creator { get; set; }
      public DateTime? CreationDate { get; set; }
      public Int64? Modifier { get; set; }
      public DateTime? ModificationDate { get; set; } 

   }
}
