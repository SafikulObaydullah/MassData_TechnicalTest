
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
   public class DocUploadVM
   {
      public Int64 ID { get; set; }
      public Int64 TransactionTypeAttributeID { get; set; }
      public Int64 TransactionID { get; set; }
      public string? DocName { get; set; }
      public string? DocExtension { get; set; }
      public string? FileName { get; set; }
      public string? AttributeName { get; set; }
      public Int64 AttributeTypeID { get; set; }
      public Int64 SampleCategoryID { get; set; }
      public string? SampleTypeName { get; set; }
      public string? SampleTypeDescription { get; set; }
      public Boolean? IsActive { get; set; }
      public Int64 Creator { get; set; }
      public DateTime? CreationDate { get; set; }
      public Int64? Modifier { get; set; }
      public DateTime? ModificationDate { get; set; }

   }
}
