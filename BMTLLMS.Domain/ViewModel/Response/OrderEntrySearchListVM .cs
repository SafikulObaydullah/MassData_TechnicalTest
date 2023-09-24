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
    public class OrderEntrySearchListVM
    {
        public Int64 OrderCode { get; set; }
        public Guid GID { get; set; }
        public Int64 CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? OrderDateFrom { get; set; }
        public DateTime? OrderDateTo { get; set; }
        public DateTime? DeliveryDateFrom { get; set; }
        public DateTime? DeliveryDateTo { get; set; }
        public string? Description { get; set; }
        public string? PaymentInfo { get; set; }
        public string? SampleStatus { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
