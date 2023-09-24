using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
    public class OrderEntryChildVM
    {
        public Int64 ID { get; set; }
        public Int64 ParentID { get; set; }
        public string? BatchLot { get; set; }
        public Int64 Producer { get; set; }
        public Int64 TestStandardId { get; set; }
        public string? TestStandardName { get; set; }
        public Int64 SampleCategoryId { get; set; }
        public string? SampleCategoryName { get; set; }
        public Int64 SampleTypeId { get; set; }
        public string? SampleTypeName { get; set; }
        public Int64 TestId { get; set; }
        public string? TestName { get; set; }
        
        public Int64 MeasurementUnitId { get; set; }
        public Int64 ReqNumberOfSamplePcs { get; set; }
        //public decimal? ExpressPrice { get; set; }
        //public decimal? RegularPrice { get; set; }
        public decimal? Price { get; set; }
        public Int64 QtyPerSample { get; set; }
        public string? SampleID { get; set; }
        public string? Note { get; set; }

        public DateTime DeliveryDate { get; set; }
        public Boolean? IsActive { get; set; }
        public Int64 Creator { get; set; }
        public DateTime? CreationDate { get; set; }
        public Int64? Modifier { get; set; }
        public DateTime? ModificationDate { get; set; }

    }
}
