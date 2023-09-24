
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
    public class OrderEntrySearchVM
    {
        public Int64 OrderCode { get; set; }
        public Int64 CustomerID { get; set; }
        //public DateTime? OrderDate { get; set; }
        //public string? CustomerName { get; set; }
        //public DateTime? DeliveryDate { get; set; }
        public string? OrderDateFrom { get; set; }
        public string? OrderDateTo { get; set; }
        public string? DeliveryDateFrom { get; set; }
        public string? DeliveryDateTo { get; set; }
        //public string? Description { get; set; }
        //public string? PaymentInfo { get; set; }
        //public string? SampleStatus { get; set; }


    }
}
