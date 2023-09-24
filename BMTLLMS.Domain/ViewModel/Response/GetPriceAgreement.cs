using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Response
{
   public class GetPriceAgreement
   {
      public Int64 ID { get; set; }
      public Int64 CustomerID { get; set; }
      public DateTime AgreementDate { get; set; }
      public DateTime EffectiveDateFrom { get; set; }
      public DateTime EffectiveDateTo { get; set; }
      public string Description { get; set; }
      public string Signee_id { get; set; }
      public string CustomerSideSigneeName { get; set; }
      public string CustomerSideSigneeDesignation { get; set; }
      public bool IsActive { get; set; }
      public Int64 ChildID { get; set; }
      public Int64 ParentID { get; set; }
      public Int64 TestStandardID { get; set; }
      public Int64 SampleTypeID { get; set; }
      public decimal RegularPrice { get; set; }
      public decimal ExpressPrice { get; set; }
      public Int64 CurrencyID { get; set; }
      public string Note { get; set; } 
   }
}
