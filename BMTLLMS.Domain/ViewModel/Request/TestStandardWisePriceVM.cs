using BMTLLMS.Domain.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
   public class TestStandardWisePriceVM
   {
      public Int64 TestStandardWisePriceID { get; set; }
      public Int64 TestStandardWiseID { get; set; }
      public Int64 CurrencyWiseID { get; set; }
      public Int64 RegularDeliveryDays { get; set; }
      public Int64 ExpressDeliveryDays { get; set; }
      public decimal RegularPrice { get; set; }
      public decimal ExpressPrice { get; set; }
      public DateTime EffectiveDateFrom { get; set; }
      public DateTime? EffectiveDateTo { get; set; }
      public string? TestStandardWiseName { get; set; }
      public Int64 TestNameID { get; set; }
      public string? CurrencyWiseName { get; set; }
      public string? ShortName { get; set; }
      public Boolean? IsActive { get; set; }
      public Int64 Creator { get; set; }
      public DateTime? CreationDate { get; set; }
      public Int64? Modifier { get; set; }
      public DateTime? ModificationDate { get; set; }

   }
}
