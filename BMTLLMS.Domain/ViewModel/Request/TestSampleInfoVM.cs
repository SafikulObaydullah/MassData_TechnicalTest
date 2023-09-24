
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
    public class TestSampleInfoVM
    {
        public Int64 SampleCategoryId { get; set; }
        public string? SampleCategoryName { get; set; }
        public Int64 SampleTypeID { get; set; }
        public string? SampleTypeName { get; set; }
        public Int64 DefaultMeasurementUnitId { get; set; }
        public Int64 ReqNumberOfSamplePcs { get; set; }
        public Int64 TestStandardID { get; set; }
        public string? TestStandardName { get; set; }
        public Int64 TestNameID { get; set; }
        public string? TestName { get; set; }
        public string? UnitName { get; set; }
        public decimal QtyPerSample { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal ExpressPrice { get; set; }
        public Int64 RegularDeliveryDays { get; set; }
        public Int64 ExpressDeliveryDays { get; set; }


    }
}
