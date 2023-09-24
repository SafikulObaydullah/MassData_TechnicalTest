
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
    public class OrderEntryVM
    {
        public Int64 ID { get; set; }
        public Int64 CustomerId { get; set; }
        public string? ContactName { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactMobile { get; set; }
        public string? ContactAddress { get; set; }
        public Int64 ProjectId { get; set; }
        public string? ProjectRefNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public Boolean? IsPaid { get; set; }
        // public DateTime? lastPaymentDate { get; set; }
        public string? Description { get; set; }
        public string? DiscountAmount { get; set; }
        public bool IsCancel { get; set; }
        public string? PaymentMode { get; set; }
        public Int64 CurrencyCode { get; set; }
        // public Boolean? IsActive { get; set; }
      
        public Int64 Creator { get; set; }
        public DateTime? CreationDate { get; set; }
        public Int64? Modifier { get; set; }
        public DateTime? ModificationDate { get; set; }


        public List<OrderEntryChildVM> OrderEntryChildList { get; set; }


    }
}
