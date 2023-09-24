using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassData.Domain.ViewModel.Request
{
   public partial class GlobalFileUrl
   {
      public long IntDocumentId { get; set; }
      public string StrTableReferrence { get; set; } = null!;
      public string StrFileServerId { get; set; } = null!;
      public string? StrRefferenceDescription { get; set; }
      public long? IntDocumentTypeId { get; set; }
      public string StrDocumentName { get; set; } = null!;
      public decimal NumFileSize { get; set; }
      public string StrFileExtension { get; set; } = null!;
      public string? StrServerLocation { get; set; }
      public long IntAccountId { get; set; }
      public long IntBusinessUnitId { get; set; }
      public DateTime DteCreatedAt { get; set; }
      public long? IntCreatedBy { get; set; }
      public DateTime? DteUpdatedAt { get; set; }
      public long? IntUpdatedBy { get; set; }
      public bool? IsActive { get; set; }
   }
}
