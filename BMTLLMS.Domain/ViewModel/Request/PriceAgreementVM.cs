
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
   public class PriceAgreementVM
   {
      public Int64 ID { get; set; }
      public Int64 CustomerID { get; set; }
      public DateTime AgreementDate { get; set; }
      public DateTime EffectiveDateFrom { get; set; }
      public DateTime EffectiveDateTo { get; set; }
      public string? Description { get; set; }
      public string? AttachementAgreement { get; set; }
      public string? Signee_id { get; set; }
      public string? CustomerSideSigneeName { get; set; }
      public string? CustomerSideSigneeDesignation { get; set; }
      public string? CustomerName { get; set; }
      public string? ContactPersonName { get; set; }
      public string? ContactEmail { get; set; }
      public string? ContactAddress { get; set; }
      public Boolean? IsActive { get; set; }
      public Int64 Creator { get; set; }
      public DateTime? CreationDate { get; set; }
      public Int64? Modifier { get; set; }
      public DateTime? ModificationDate { get; set; }
      public List<PriceAgreementChildVM>? PriceAgreementChildList { get; set; }

   }
}
