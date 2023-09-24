
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
    public class SpecificationHeadVM
    {
        public Int64 ID { get; set; }
        public string? Name { get; set; }
        public Int64 MeasurementUnitID { get; set; }
        public string? MeasurementUnitName  { get; set; }
        public Boolean? IsActive { get; set; }
        public Int64 Creator { get; set; }
        public DateTime? CreationDate { get; set; }
        public Int64? Modifier { get; set; }
        public DateTime? ModificationDate { get; set; }

    }
}
