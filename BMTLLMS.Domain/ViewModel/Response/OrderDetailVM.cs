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
    public class OrderDetailVM
    {
        public Int64 ID { get; set; }
        public Int64 CustomerID { get; set; }
        public string? ContactName { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactMobile { get; set; }
        public string? ContactAddress { get; set; }
        public Int64 ProjectID { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool IsPaid { get; set; }
        public string? Description { get; set; }
        // public decimal DiscountAmount { get; set; }
        //public bool IsCancel { get; set; }
        public string? PaymentMode { get; set; }
        public Int64 CurrencyCode { get; set; }
        public Int64 SampleCategoryID { get; set; }
        public string? SampleCategoryName { get; set; }
        public Int64 SampleTypeID { get; set; }
        public string? SampleTypeName { get; set; }
        public Int64 ProducerID { get; set; }
        public string? LotNo { get; set; }
        public Int64 ReqNumberOfSamplePcs { get; set; }
        public Int64 MeasurementUnitID { get; set; }
        public decimal QtyPreSample { get; set; }
        public string? RetenedSampleID { get; set; }
        public string? Note { get; set; }
        public bool IsSentForProcessing { get; set; } 
        public Int64 SampleID { get; set; }
        public Int64 TestStandardID { get; set; }
        public string? TestStandardName { get; set; }
        public Int64 TestNameID { get; set; }
        public string? TestName { get; set; }
        public Int64 QtyNumber { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime? DeliveryDate { get; set; }


    }
}
