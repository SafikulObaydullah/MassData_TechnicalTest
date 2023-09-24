using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
   public class PriceAgreementParentAndChildVM
   {
      public Int64 ID { get; set; }
      public Int64 CustomerID { get; set; }
      public string? CustomerName { get; set; }
      public DateTime AgreementDate { get; set; }
      public DateTime EffectiveDateFrom { get; set; }
      public DateTime EffectiveDateTo { get; set; }
      public Int64 ParentID { get; set; }
      public Int64 ChildID { get; set; }
      public Int64 TestStandardID { get; set; }
      public string? TestStandardName { get; set; }
      public decimal RegularPrice { get; set; }
      public decimal ExpressPrice { get; set; }
      public Int64 CurrencyID { get; set; }
      public string? CurrencyName { get; set; } 
   }
}
