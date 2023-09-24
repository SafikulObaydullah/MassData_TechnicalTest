using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
   public class SampleReceiveSearchListVM
   {
      public Int64 OrderRefNo { get; set; }
      public string? OrderDateFrom { get; set; }
      public string? OrderDateTo { get; set; }
      public long CustomerID { get; set; }
      public long StatusID  { get; set; }
      public string? DeliveryDateFrom { get; set; }
      public string? DeliveryDateTo { get; set; }
      //public Int64 CreatorId { get; set; }
   }  
      
}     