
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
   public class PriceAgreementSearchVM
   {
      public Int64 ID { get; set; }
      public string? CustomerName { get; set; }
      public Int64? CustomerID { get; set; }
      public string? AgreementDate { get; set; }
      public string? AgreementToDate { get; set; }
      public string? EffectiveDateFrom { get; set; }
      public string? EffectiveDateTo { get; set; }
      public Boolean? IsActive { get; set; }  
   }
}
