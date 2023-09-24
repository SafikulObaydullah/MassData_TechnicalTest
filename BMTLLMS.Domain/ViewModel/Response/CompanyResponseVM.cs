using BMTLLMS.Domain.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Response
{
   public class CompanyResponseVM
   {
      public string StatusCode { get; set; }
      public string StatusMessage { get; set; } = string.Empty;
      public IEnumerable<Company> Data { get; set; }
   }
}
