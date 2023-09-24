
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
    public class SampleTypeVsTestStandardVM
    {
        public Int64 ID { get; set; }
        public Int64 SampleTypeID { get; set; }
        public string? SampleTypeName { get; set; }
        public Int64 TestStandardID { get; set; }
        public string? TestStandardName { get; set; }
        public int ReqNumberOfSamplePcs { get; set; }
        public decimal QtyPerSample { get; set; }
        public string? ReqSampleDescription { get; set; }
        public Boolean? IsActive { get; set; }
        public Int64 Creator { get; set; }
        public DateTime? CreationDate { get; set; }
        public Int64? Modifier { get; set; }
        public DateTime? ModificationDate { get; set; }

    }
}
