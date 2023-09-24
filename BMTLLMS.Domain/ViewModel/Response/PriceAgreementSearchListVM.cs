using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel.Request;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace BMTLLMS.Domain.ViewModel.Response
{
    public class PriceAgreementSearchListVM
    {
      public Int64 ID { get; set; }
      public string? CustomerName { get; set; }
      public Int64 CustomerID { get; set; }
      public DateTime? AgreementDate { get; set; }
      public DateTime? AgreementToDate { get; set; }
      public DateTime? EffectiveDateFrom { get; set; }
      public DateTime? EffectiveDateTo { get; set; }
      public Boolean? IsActive { get; set; } 
   }
}
