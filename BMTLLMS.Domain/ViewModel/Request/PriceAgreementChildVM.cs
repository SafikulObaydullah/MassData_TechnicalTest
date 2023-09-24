using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
   public class PriceAgreementChildVM
   {
      public Int64 ID { get; set; }
      public Int64 ParentID { get; set; } 
      public Int64 ChildID { get; set; } 
      public Int64 TestStandardID { get; set; }
      public Int64 SampleTypeID { get; set; }
      public decimal RegularPrice { get; set; }
      public decimal ExpressPrice { get; set; }
      public string? Note { get; set; }
      public Int64 CurrencyID { get; set; }
      public string? CurrencyName { get; set; }
      public Int64 CustomerID { get; set; }
      public string? CustomerSideSigneeName { get; set; }
      public string? TestStandardName { get; set; }
      public Int64 TestNameID { get; set; }
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
