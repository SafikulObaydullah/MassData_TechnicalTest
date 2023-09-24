
using BMTLLMS.Domain.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
    public class OrderDetailsListVM
    {
         public Int64 ID { get; set; }
         public DateTime OrderDate { get; set; }
         public DateTime OrderDateTo { get; set; }
         public DateTime DeliveryDateFrom { get; set; }  
         public DateTime DeliveryDateTo { get; set; } 
         public Int64 CustomerID { get; set; }
         public Int64 StatusID { get; set; }
         public string? CustomerName { get; set; } 
         public string? Description { get; set; }
         public Int64 TestStandardCount { get; set; }
         public string? SampleType { get; set; }
         public Int64 SampleTypeID { get; set; }
         public Int64 SampleID { get; set; } 
         public Int64 SpecificationID { get; set; } 
         public string? SpecificationValue { get; set; } 
         public string? SampleCategory { get; set; }
         public Int64 ReqNumberOfSamplePcs { get; set; }
         public decimal QtyPerSample   { get; set; }
         public string? MeasurementUnitName { get; set; }
         public string? StatusName { get; set; }
   }
}
