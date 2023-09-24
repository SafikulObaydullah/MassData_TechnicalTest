using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.Models.Configuration
{
    public class SampleType
    {

        public Int64 Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Int64 SampleCategoryID { get; set; }
        public string? CategoryName { get; set; }
        public Boolean isActive { get; set; }
        public Int64 Creator { get; set; }
        public DateTime? CreationDate { get; set; }
        public Int64? Modifier { get; set; }
        public DateTime? ModificationDate { get; set; }


    }
}
