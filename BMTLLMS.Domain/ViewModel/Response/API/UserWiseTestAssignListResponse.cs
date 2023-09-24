using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Response.API
{
    public class UserWiseTestAssignListResponse
    {
        public string SampleCategoryName { get; set; }
        public Int64 SampleCategoryNameId { get; set;}
        public Int64 SampleTypeNameId { get; set; }
        public string SampleTypeName { get; set; }
        public string TestNameName { get; set; }
        public Int64 TestNameId { get; set; }
        public string TestStandardName { get; set; }
        public Int64 TestStandardNameId { get;set; }
        public Int64 OrderChildSampleId { get; set; }
        public Int64 OrderChildTestStanderdID { get;set; }

        public DateTime DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }


    }
}
