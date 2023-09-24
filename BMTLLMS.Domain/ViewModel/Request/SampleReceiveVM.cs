using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
   public class SampleReceiveVM
   {
      public Int64 ID { get; set; } 
      public Int64 SampleID { get; set; }
      public Int64 SampleConditionID { get; set; } 
      public Int64 SpecificationID { get; set; } 
      public Int64 NumberOfSamplePcs { get; set; }
      public Int64 QtyPerSample { get; set; }
      public Int64 ReceivedByID { get; set; }
      public DateTime ReceivedDateTime { get; set; }
      public Int64 RetenedSampleID { get; set; }
      public string? Note { get; set; }
      public Boolean? IsActive { get; set; }
      public Int64 Creator { get; set; }
      public DateTime? CreationDate { get; set; }
      public Int64? Modifier { get; set; }
      public DateTime? ModificationDate { get; set; }
      public List<SampleSpecificationVM> SamplesSpecificationList { get; set; }

   }
}
