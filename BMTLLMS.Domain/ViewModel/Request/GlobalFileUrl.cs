using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassData.Domain.ViewModel.Request
{
   public partial class GlobalFileUrl
   {
      public Int64 ID { get; set; }
      public string? ReferrenceNo { get; set; } 
      public string? FileServerId { get; set; }
      public string? ReferenceDescription { get; set; }
      public Int64? DocumentTypeId { get; set; }
      public string? DocumentName { get; set; }
      public decimal? NumFileSize { get; set; }
      public string? FileExtension { get; set; }
      public string? ServerLocation { get; set; }
      public Boolean? IsActive { get; set; }
      public Int64 Creator { get; set; }
      public DateTime? CreationDate { get; set; }
      public Int64? Modifier { get; set; }
      public DateTime? ModificationDate { get; set; }
   }
}
