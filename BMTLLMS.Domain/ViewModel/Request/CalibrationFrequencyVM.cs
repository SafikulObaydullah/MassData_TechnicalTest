
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
    public class CalibrationFrequencyVM
    {
        public Int64 ID { get; set; }

        public Int64 MachineID { get; set; }
        public string? MachineName { get; set; }

        public decimal? CorrectionFactor { get; set; }
        public Int64 MeasurementUnitID { get; set; }
        public string? MeasurementUnitName { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public Int64 CalibrationFrequencyInDays { get; set; }
        public Int64 CalibrationFrequencyInTestNumber { get; set; }
        public Boolean? IsActive { get; set; }
        public Int64 Creator { get; set; }
        public DateTime? CreationDate { get; set; }
        public Int64? Modifier { get; set; }
        public DateTime? ModificationDate { get; set; }

    }
}
